using Controllers;
using ObjectPooling;
using UnityEngine;

public class FireDefault : MonoBehaviour
{
    public static void Fire(Vector3 sourcePos, Quaternion sourceRot, Vector3 targetPos)
    {
        Projectile projectile = ProjectilePool.Instance.Get();

        projectile.transform.position = sourcePos;
        projectile.transform.LookAt(targetPos);
        
        Vector3 direction = targetPos - sourcePos;
        
        projectile.GetComponent<Rigidbody>().AddForce(
            direction.normalized * projectile.ProjectileVelocity);
    }
}
