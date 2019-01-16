using System;
using Interfaces;
using UnityEngine;

namespace Traits
{
    [RequireComponent(typeof(Damageable))]
    public class Killable : MonoBehaviour, IKillable
    {
        public event Action OnDied = delegate() { } ;

        private Damageable damageable;
    
        private void Start()
        {
            GetComponent<IDamageable>().OnDamaged += HandleOnDamaged;
            damageable = GetComponent<Damageable>();
        }

        private void HandleOnDamaged(int amount)
        {
            if (damageable.GetHealth() <= damageable.GetMinHealth()) {
                Kill();
            }
        }
    
        public void Kill()
        {
            OnDied();
        }

    }
}
