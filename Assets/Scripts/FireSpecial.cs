using UnityEngine;

public static class FireSpecial
{
    public static void Fire(Vector3 sourcePos, Quaternion sourceRot, Vector3 targetPos)
    {
        FireDefault.Fire(sourcePos, sourceRot, targetPos);
        FireDefault.Fire(sourcePos + (Vector3.left), sourceRot, targetPos);
        FireDefault.Fire(sourcePos + (Vector3.right), sourceRot, targetPos);
    }
}
