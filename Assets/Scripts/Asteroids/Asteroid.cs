using UnityEngine;

public class Asteroid : MonoBehaviour, IDestructable
{
    [SerializeField] private AsteroidSettings _data;
    public AsteroidSettings Data { set => _data = value; }

    private IReward _reward;
    private AsteroidMotor _motor;

    private float _size;
    private int _partsCount;

    private float getSize() => transform.localScale.x; 
    private int getScoreReward() => Mathf.RoundToInt(_data.StartReward + (_data.StartSize - _size) * (_data.MaxReward - _data.StartReward)); // Считаем награду в зависимости от размера
    private float getSpeed() // Считаем скорость в зависимости от рамзера
    {
        float speed = _data.StartSpeed * Random.Range(1.0f, 2.0f) + (1 - _size / _data.StartSize) * (_data.MaxSpeed - _data.StartSpeed);
        return speed;
    }
    private int getPartsCount() // Считаем кол-во частей астероида
    {
        int partsCount = 0;
        if (_size / _data.MinPartsAfterDestroy >= _data.MinSize)
        {
            int maxPossibleParts = Mathf.FloorToInt(_size / _data.MinSize);
            int maxBound = Mathf.Min(maxPossibleParts, _data.MaxPartsAfterDestroy);
            partsCount = Random.Range(_data.MinPartsAfterDestroy, maxBound);
        }
        return partsCount;

    }
    private void OnEnable() // Инициализация астероида
    {
        if (_data == null)
        {
            Debug.LogError("No Asteroid Data provided!");
            return;
        }

        _size = getSize();
        _reward = new ScoreReward(getScoreReward());
        _partsCount = getPartsCount();
        _motor = new AsteroidMotor(transform, getSpeed());
    }

    private void Update() // Двигаемся
    {
        _motor.Tick();
    }

    public void Destruct(GameObject source) // Уничтожаемся
    {
        SpawnParts();
        AsteroidSounds.Instance.PlaySound("Boom");
        ExplosionController.MakeExplosion(transform.position);
        if (!source.TryGetComponent<Spaceship>(out _))
        {
            _reward.GiveReward();
        }
        AsteroidPool.Instance.SendToPool(this);
    }

    private void SpawnParts() // Спавним части после смерти
    {
        for (int i = 0; i < _partsCount; i++)
        {
            Vector2 newPos = transform.position;
            Vector2 newScale = transform.localScale / _partsCount;
            float newRot = transform.rotation.eulerAngles.z + Random.Range(_data.MinDeflectionAngle, _data.MaxDeflectionAngle);
            AsteroidGenerator.Instance.GenObject(newPos, newScale, newRot);
        }
    }
}
