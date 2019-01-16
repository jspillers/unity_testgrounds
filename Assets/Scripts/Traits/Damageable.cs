using System;
using Interfaces;
using UnityEngine;

namespace Traits
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private int minHealth = 0;
        [SerializeField] private int maxHealth = 20;
        [SerializeField] private int health = 0;

        public event Action<int> OnDamaged = delegate(int i) { } ;
    
        private void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            health = Mathf.Max(health - amount, minHealth);
        
            OnDamaged(amount);
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public int GetMinHealth()
        {
            return minHealth;
        }
    }
}
