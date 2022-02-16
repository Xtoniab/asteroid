using UnityEngine;

[CreateAssetMenu(menuName = "Asteroid/Settings", fileName = "AsteroidData")]
public class AsteroidSettings : ScriptableObject
{
    [Tooltip("Начальное кол-во очков за уничтожение астероида.")]
    [SerializeField] private int _startReward = 0;
    [Tooltip("Максимальная кол-во очков за уничтожение астероида.")]
    [SerializeField] private int _maxReward = 0;
    [Tooltip("Начальная скорость астероида.")]
    [SerializeField] private float _startSpeed = 0;
    [Tooltip("Максимальная скорость астероида.")]
    [SerializeField] private float _maxSpeed = 0;
    [Tooltip("Минимальное число частей на которые может разделиться астероид.")]
    [SerializeField] private int _minPartsAfterDestroy = 0;
    [Tooltip("Максимальное число частей на которые может разделиться астероид.")]
    [SerializeField] private int _maxPartsAfterDestroy = 0;
    [Tooltip("Минимальный угол отклонения астероида, при разрушении.")]
    [SerializeField] private float _minDeflectionAngle = 0;
    [Tooltip("Максимальный угол отклонения астероида, при разрушении.")]
    [SerializeField] private float _maxDeflectionAngle = 0;
    [Tooltip("Размер первого астероида.")]
    [SerializeField] private float _startSize = 0;
    [Tooltip("Минимальный размер с котороым астероид может существовать.")]
    [SerializeField] private float _minSize = 0;

    public int StartReward { get => _startReward; }
    public int MaxReward { get => _maxReward; }
    public float StartSpeed { get => _startSpeed; }
    public float MaxSpeed { get => _maxSpeed; }
    public int MinPartsAfterDestroy { get => _minPartsAfterDestroy; }
    public int MaxPartsAfterDestroy { get => _maxPartsAfterDestroy; }
    public float MinDeflectionAngle { get => _minDeflectionAngle; }
    public float MaxDeflectionAngle { get => _maxDeflectionAngle; }
    public float MinSize { get => _minSize; }
    public float StartSize { get => _startSize; }
}
