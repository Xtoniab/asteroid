using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ExplosionParticleSystem : MonoBehaviour
{
    private ParticleSystem ps;

    public ExplosionParticleSystemPool ExplosionParticleSystemPool
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!ps.IsAlive()) // Частиый больше нет -> отправляемся в пулл
        {
            ExplosionParticleSystemPool.Instance.SendToPool(this);
        }
    }
}
