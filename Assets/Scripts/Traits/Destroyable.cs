using Interfaces;
using UnityEngine;

namespace Traits
{
    [RequireComponent(typeof(Killable))]
    public class Destroyable : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<IKillable>().OnDied += HandleOnDied;
        }

        private void HandleOnDied()
        {
            Destroy(gameObject); 
        }
    }
}