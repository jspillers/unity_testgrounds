using Controllers;
using Interfaces;
using UnityEngine;

namespace Traits
{
    [RequireComponent(typeof(Shooter))]
    public class AimAtTargetable : MonoBehaviour, IAimAtTargetable
    {
        private Target target;
        private Rigidbody targetRb;
        private GameObject aimAheadObject;
    
        private Shooter shooter;

        private void Start()
        {
            shooter = GetComponent<Shooter>();
        
            target = FindObjectOfType<Target>();
            targetRb = target.GetComponent<Rigidbody>();
        
            aimAheadObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            aimAheadObject.transform.localScale = Vector3.one * 0.25f;
            aimAheadObject.GetComponent<Renderer>().material.color = Color.red;
            aimAheadObject.GetComponent<Collider>().enabled = false;
        }

        private void FixedUpdate()
        {
            if (target) {
                aimAheadObject.transform.position = AimAhead.FindPosition(
                    transform, 
                    target.transform,
                    shooter.ProjectilePrefab.GetComponent<Projectile>().ProjectileVelocity * 2f
                ); 
            }
        }

        public Target GetCurrentTarget()
        {
            return target;
        }

        public GameObject GetAimAheadObject()
        {
            return aimAheadObject;
        }
    }
}
