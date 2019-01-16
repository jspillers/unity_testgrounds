using System;

namespace Interfaces
{
    public interface IKillable
    {
        event Action OnDied;
    
        void Kill();
    }
}
