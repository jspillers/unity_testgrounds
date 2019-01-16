using UnityEngine;

namespace Controllers
{
    public class Target : MonoBehaviour
    {
        private Rigidbody rb;
    
        [SerializeField] private float forceMultiplier = 20f;
    
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKey("w"))
                rb.AddForce(Vector3.forward * forceMultiplier);
            
            if (Input.GetKey("s"))
                rb.AddForce(Vector3.back * forceMultiplier);
        
            if (Input.GetKey("a"))
                rb.AddForce(Vector3.left * forceMultiplier);
        
            if (Input.GetKey("d"))
                rb.AddForce(Vector3.right * forceMultiplier);
        }
    }
}
