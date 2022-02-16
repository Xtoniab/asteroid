using UnityEngine;

public class AsteroidGenerator : PoolObjectGenerator<Asteroid>
{
    [SerializeField] protected AsteroidSettings _data;
    protected override void SetUpObject(Asteroid obj, Vector2 pos, Vector3 scale, float rotation)
    {
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0,360));
        obj.transform.localScale =  scale.x > 0 ? scale : Vector3.one * _data.StartSize;  
    }

}
