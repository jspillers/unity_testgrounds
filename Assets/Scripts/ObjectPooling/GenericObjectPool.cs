using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;
        [SerializeField] private int initialObjectCount;
    
        public static GenericObjectPool<T> Instance { get; private set; }
    
        private readonly Queue<T> objects = new Queue<T>();

        private void Awake()
        {
            Instance = this;
            
            if (initialObjectCount > 0)
                AddObjects(initialObjectCount);
        }

        public T Get()
        {
            if (objects.Count == 0)
                AddObject();
        
            T obj = objects.Dequeue();
        
            obj.gameObject.SetActive(true);
        
            return obj;
        }

        public void ReturnToPool(T objectToReturn)
        {
            ResetTransform(objectToReturn);
            
            objectToReturn.gameObject.SetActive(false);
            objects.Enqueue(objectToReturn);
        }

        private void AddObjects(int count)
        {
            int i = 0;
            
            while (i < count) {
                AddObject();
                i++;
            }
        }

        private void AddObject()
        {
            T newObject = GameObject.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            
            ResetTransform(newObject);
            
            objects.Enqueue(newObject);
        }

        private void ResetTransform(T objectToReturn)
        {
            Transform objectTransform = objectToReturn.GetComponent<Transform>();

            if (!objectTransform) return;
            
            objectTransform.position = Vector3.zero;
            objectTransform.rotation = Quaternion.identity; 
            objectTransform.parent = transform;
        }
    }
}
