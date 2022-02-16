using UnityEngine;

[CreateAssetMenu(menuName = "Spaceship/Gun/Settings", fileName = "GunData")]
public class ShipGunData : ScriptableObject
{
    [Tooltip("Скорострельность оружия.(Сколько выстрелов возможно произвести за 1 секунду.)")]
    [SerializeField] private float _fireRate = 0;
    [Tooltip("Скорость пуль.")]
    [SerializeField] private float _bulletSpeed = 0;
    [Tooltip("Сколько секунд будет существовать пуля после выстрела.")]
    [SerializeField] private float _bulletLifeTime = 0;


    public float FireRate { get => _fireRate; }
    public float BulletSpeed { get => _bulletSpeed; }
    public float BulletLifeTime { get => _bulletLifeTime; }
}
