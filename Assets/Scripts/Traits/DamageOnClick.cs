using Interfaces;
using UnityEngine;

namespace Traits
{
    public class DamageOnClick : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hitinfo;

                if (Physics.Raycast(ray, out hitinfo)) {
                    Debug.Log("click hit");
                    IDamageable damageable = hitinfo.collider.GetComponent<IDamageable>();

                    damageable?.TakeDamage(1);
                }
            } 
        }
    }
}
