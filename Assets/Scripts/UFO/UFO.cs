using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UFO : MonoBehaviour, IDestructable
{
    [SerializeField] private SpaceshipData _shipData;
    [SerializeField] private float _soundRate = 0f;
    [SerializeField] private int _scoreReward = 50;

    private IReward _reward;
    private SpaceshipMotor _motorVertical;
    private SpaceshipMotor _motorHorizontal;
    private IShipInput _inputVertical;
    private IShipInput _inputHorizontal;
    private Rigidbody2D _rg;

    private float _time = 0f;

    private void Awake()
    {
        _rg = GetComponent<Rigidbody2D>();
    }
    public void Destruct(GameObject source) // Уничтожение UFO
    {
   
        AsteroidSounds.Instance.PlaySound("Boom");
        ExplosionController.MakeExplosion(transform.position);
        if (!source.TryGetComponent<Spaceship>(out _))
        {
            _reward.GiveReward();
        }
        UFOPool.Instance.SendToPool(this);
    }

    private void OnEnable() // Инициализация компонентов
    {
        _reward = new ScoreReward(_scoreReward);
        _inputVertical = new UFOInput();
        _motorVertical = new SpaceshipMotor(_inputVertical, _shipData, _rg, Direction.UP);
        _inputHorizontal = new UFOInput();
        _motorHorizontal = new SpaceshipMotor(_inputHorizontal, _shipData, _rg, Direction.RIGHT);
    }
    private void HandleSound()
    {
        _time -= Time.deltaTime;
        if(_time <= 0)
        {
            UFOSounds.Instance.PlaySound("Background");
            _time = _soundRate;
        }
    }
    void Update()
    {
        HandleSound();

        _inputVertical.ReadInput();
        _inputHorizontal.ReadInput();
        _motorVertical.Tick();
        _motorHorizontal.Tick();
    }
}
