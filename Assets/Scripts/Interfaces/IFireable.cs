using System;
using UnityEngine;

namespace Interfaces
{
    public interface IFireable {
        event Action OnFire;
    }
}
