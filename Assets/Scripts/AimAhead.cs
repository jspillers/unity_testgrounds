using UnityEngine;

public static class AimAhead
{
    public static Vector3 FindPosition(Transform aimSource, Transform target, float muzzleVelocity)
    {
        Rigidbody targetRb = target.GetComponent<Rigidbody>();
        
        Vector3 relativeVelocity = targetRb.velocity - aimSource.GetComponent<Rigidbody>().velocity;
        
        Vector3 delta = target.position - aimSource.position;
        
        float a = Vector3.Dot(relativeVelocity, relativeVelocity) - muzzleVelocity * muzzleVelocity;
        float b = 2f * Vector3.Dot(relativeVelocity, delta);
        float c = Vector3.Dot(delta, delta);

        float det = b * b - 4f * a * c;

        float timeToTarget = det > 0f ? 2f * c / (Mathf.Sqrt(det) - b) : -1f;

        return target.position + targetRb.velocity * timeToTarget;
    }
}
