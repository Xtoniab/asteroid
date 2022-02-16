using UnityEngine;

public class Bullet : MonoBehaviour, IDestructable
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _maxLifeTime = 0f;

    private float _lifeTime = 0f;

    public float MaxLifeTime { set => _maxLifeTime = value; }
    public float Speed { set => _speed = value; }

    public BulletPool BulletPool
    {
        get => default;
        set
        {
        }
    }

    private void OnEnable() // Инициализация
    {
        _lifeTime = _maxLifeTime;
    }
    public void Destruct(GameObject source) // Отправляем в пулл, при уничтожении
    {
        BulletPool.Instance.SendToPool(this);
    }

    private void Move() // Двигаемся
    {
        transform.Translate(Vector2.up* _speed / 10f * Time.deltaTime);
    }
    private void HandleLifeTime(float dt) // Не пора ли нам в пулл?
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destruct(gameObject);
        }
    }

    private void Update()
    {
        Move();
        HandleLifeTime(Time.deltaTime);
    }
}
