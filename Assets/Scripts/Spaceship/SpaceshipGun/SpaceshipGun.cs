using UnityEngine;

public class SpaceshipGun : MonoBehaviour
{
    [SerializeField] private ShipGunData _data;
    [SerializeField] private Transform _barrel;

    private IGunInput _input;
    private float _secBeforeShot = 0;


    private void Awake()
    {
        _input = new SpaceshipGunInput();
    }

    private void Shot()
    {
        Bullet bullet = BulletPool.Instance.Get();
        bullet.transform.position = _barrel.position;
        bullet.transform.rotation = _barrel.transform.rotation;
        bullet.MaxLifeTime = _data.BulletLifeTime;
        bullet.Speed = _data.BulletSpeed;
        bullet.gameObject.SetActive(true);

        ShipSounds.Instance.PlaySound("Shot");
    }
    private void HandleRateTimer()
    {
        _secBeforeShot -= Time.deltaTime;
        if (_secBeforeShot < 0)
        {
            _secBeforeShot = 0;
        }
    }
    private void TryToShoot()
    {
        if (_secBeforeShot == 0)
        {
            if (_input.IsFire)
            {
                Shot();
                _secBeforeShot = 1 / _data.FireRate;
            }
        }
    }
    private void Update()
    {
        _input.ReadInput();
        HandleRateTimer();
        TryToShoot();
    }
}
