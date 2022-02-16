using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [Tooltip("При попытки взять объект из пулла, будет возвращён случайный объект из данного списка.")]
    [SerializeField] private T[] _prefabs;

    private static ObjectPool<T> _instance;
    private Queue<T> _objects = new Queue<T>();
    public static ObjectPool<T> Instance {
        get
        {
            if(_instance == null)
            {
                Debug.LogError($"Trying to use {typeof(T).Name} objects' pool without initialization!");
            }
            return _instance;
        }
        private set
        {
            if(_instance == null)
            {
                _instance = value;
            }
            else
            {
                Debug.LogError($"Trying to initialize {typeof(T).Name} objects' pool more than one time!");
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    public T Get() // Выдача объекта из пулла
    {
        if(_objects.Count == 0)
        {
            AddObject();
        }
        return _objects.Dequeue();
    }

    public void SendToPool(T obj) // Принимаем объект в пулл
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        _objects.Enqueue(obj);
    }
    

    private void AddObject() // Если в пулле пусто, спавним новый объект
    {
        int idx = Random.Range(0, _prefabs.Length);
        var newObj = Instantiate(_prefabs[idx]);
        SendToPool(newObj);
    }
}
