using UnityEngine;

public static class ExplosionController
{
    public static void MakeExplosion(Vector2 pos) // Making boom!
    {
        var explosion = ExplosionParticleSystemPool.Instance.Get();
        explosion.transform.position = pos;
        explosion.gameObject.SetActive(true);

    }
}
