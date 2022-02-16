using UnityEngine;

[CreateAssetMenu(menuName = "Game/Settings", fileName = "GameData")]
public class GameData : ScriptableObject
{
    [Tooltip("Префаб игрока.)")]
    [SerializeField] private GameObject _playerPrefab;
    [Tooltip("Кол-во жизней у игрока.")]
    [SerializeField] private int _lives = 0;
    [Tooltip("Раз в сколько секунд спавнятся астероиды.")]
    [SerializeField] private float _asteroidTiming = 0;
    [Tooltip("В каком кол-ве спавнятся астероиды.")]
    [SerializeField] private int _asteroidCount = 0;
    [Tooltip("Раз в сколько секунд спавнятся UFO.")]
    [SerializeField] private float _ufoTiming = 0;
    [Tooltip("В каком кол-ве спавнятся UFO.")]
    [SerializeField] private int _ufoCount = 0;
    public GameObject PlayerPrefab { get => _playerPrefab; }
    public int Lives { get => _lives; }
    public float AsteroidTiming { get => _asteroidTiming; }
    public float UFOTiming { get => _ufoTiming; }
    public int AsteroidCount { get => _asteroidCount; }
    public int UFOCount { get => _ufoCount; }

}
