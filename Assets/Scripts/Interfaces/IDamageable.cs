using System;

namespace Interfaces
{
    public interface IDamageable
    {
        event Action<int> OnDamaged;
    
        void TakeDamage(int amount);
    }
}
