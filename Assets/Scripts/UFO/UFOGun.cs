using System.Collections.Generic;
using UnityEngine;

public class UFOGun : MonoBehaviour
{
    [SerializeField] private ShipGunData _data;
    [SerializeField] private List<Transform> _barrels;

    private IGunInput _input;
    private float _secBeforeShot = 0;


    private void Awake()
    {
        _input = new UFOGunInput();
    }

    private void Shot()
    {
        var barrel = _barrels[Random.Range(0, _barrels.Count - 1)];
        Bullet bullet = BulletPool.Instance.Get();
        bullet.transform.position = barrel.position;
        bullet.transform.rotation = barrel.transform.rotation;
        bullet.MaxLifeTime = _data.BulletLifeTime;
        bullet.Speed = _data.BulletSpeed;
        bullet.gameObject.SetActive(true);

        UFOSounds.Instance.PlaySound("Shot");
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
