using Controllers;
using UnityEngine;

namespace Interfaces
{
    public interface IAimAtTargetable
    {
        Target GetCurrentTarget();
        GameObject GetAimAheadObject();
    }
}