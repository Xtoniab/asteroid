using UnityEngine;

[CreateAssetMenu(menuName = "Spaceship/Settings", fileName = "SpaceshipData")]
public class SpaceshipData : ScriptableObject
{
    [Tooltip("Ускорение корабля.")]
    [SerializeField] private float _acceleration = 0;
    [Tooltip("Максимальная скорость корабля.")]
    [SerializeField] private float _maxSpeed = 0;
    [Tooltip("Скорость поворота.")]
    [SerializeField] private float _turnSpeed = 0;
    [Tooltip("Сопротивление скольжению.")]
    [SerializeField] private float _drag = 0;

    public float Acceleration { get => _acceleration; }
    public float MaxSpeed { get => _maxSpeed; }
    public float TurnSpeed { get => _turnSpeed; }
    public float Drag { get => _drag; }

    public Spaceship Spaceship
    {
        get => default;
        set
        {
        }
    }
}
