using Interfaces;
using ObjectPooling;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        public float ProjectileVelocity = 5f;
    
        [SerializeField] private int damageAmount = 1;
        [SerializeField] private float maxLifetime = 5f;
        private float lifetime;
        
        private Rigidbody rb;
        private bool hasCollided;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            lifetime -= Time.deltaTime;

            if (lifetime < 0) ReturnToPool();
        }

        private void OnEnable()
        {
            lifetime = maxLifetime;
            hasCollided = false;
            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (hasCollided) return;
            
            Debug.Log(name + " OnCollisionEnter of: " + other.collider.name);
            
            Collider otherCollider = other.collider;
        
            IDamageable damageable = otherCollider.GetComponent<IDamageable>();
            damageable?.TakeDamage(damageAmount);

            ReturnToPool();
            
            hasCollided = true;
        }

        private void ReturnToPool()
        {
            ProjectilePool.Instance.ReturnToPool(this);    
        }
    }
}
