using System;
using Interfaces;
using Traits;
using UnityEngine;

namespace Controllers
{
    public class Shooter : MonoBehaviour, IFireable
    {
        public Rigidbody ProjectilePrefab;

        public Action<Vector3, Quaternion, Vector3> FireWeapon = delegate { };
        
        public event Action OnFire = delegate { } ;

        private IAimAtTargetable aimAtTargetable; 

        private void Start()
        {
            FireWeapon = FireDefault.Fire;
            aimAtTargetable = GetComponent<IAimAtTargetable>();
        
            InvokeRepeating(nameof(FireAtTarget), 2f, 2f);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1")) {
                FireWeapon(
                    transform.position, 
                    transform.rotation, 
                    aimAtTargetable.GetAimAheadObject().transform.position
                );
            }

            if (Input.GetButton("Fire2")) {
                FireWeapon = FireSpecial.Fire;
            }
            else {
                FireWeapon = FireDefault.Fire;
            }
        }

        private void FireAtTarget()
        {
            if (aimAtTargetable.GetCurrentTarget()) {
                FireWeapon(
                    transform.position, 
                    transform.rotation, 
                    aimAtTargetable.GetAimAheadObject().transform.position
                );

                OnFire();
            }
        }
    }
}