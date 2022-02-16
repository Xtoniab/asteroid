using UnityEngine;

public abstract class PoolObjectGenerator<T> : MonoBehaviour where T : Component
{
    protected ObjectPool<T> _pool;
    private static PoolObjectGenerator<T> _instance;
    public static PoolObjectGenerator<T> Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"No {typeof(T).Name} generator at the game scene!");
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    private void Awake() => Instance = this;
    private void Start() => _pool = ObjectPool<T>.Instance;

    protected virtual void SetUpObject(T obj, Vector2 pos, Vector3 scale, float rotation)
    {
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.Euler(0, 0, rotation);
        obj.transform.localScale = -scale;
    }

    public void GenObject(Vector2 pos, Vector3 scale, float rotation)
    {
        var newObject = _pool.Get();
        SetUpObject(newObject, pos, scale, rotation);
        newObject.gameObject.SetActive(true);
    }
    public void GenRandomPlacedObjects(int count)
    {
        Bounds _cameraBounds = Camera.main.OrthographicBounds();

        for (int i = 0; i < count; i++)
        {
            float newX = Random.Range(_cameraBounds.min.x, _cameraBounds.max.x);
            float newY = Random.Range(_cameraBounds.min.y, _cameraBounds.max.y);
            Vector2 newPos = new Vector2(newX, newY);
            
            GenObject(newPos, -Vector3.one, 0);
        }
    }
}