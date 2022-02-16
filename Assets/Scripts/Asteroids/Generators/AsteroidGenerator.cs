using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AsteroidGenerator<T> : MonoBehaviour, IAsteroidGenerator where T : class, new()
{
    [SerializeField] protected AsteroidSettings _data;


    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"No {typeof(T).Name} at the game scene!");
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    private void Awake()
    {
        Instance = this as T;
    }
    public abstract void GenAsteroids(int count);

    public virtual void GenAsteroid(Vector2 pos, Vector2 scale, float rotation)
    {
        var newAsteroid = AsteroidPool.Instance.Get();
        newAsteroid.Data = _data;
        newAsteroid.transform.localScale = scale;
        newAsteroid.transform.position = pos;
        newAsteroid.transform.rotation = Quaternion.Euler(0, 0, rotation);
        newAsteroid.gameObject.SetActive(true);
    }
    
}
