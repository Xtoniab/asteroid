using UnityEngine;

public class ScreenWrappingBehavior : MonoBehaviour
{
    private Bounds _cameraBounds;
    private void Awake()
    {
        _cameraBounds = Camera.main.OrthographicBounds();
    }
    void Update()
    {
        float dx = transform.position.x;
        float dy = transform.position.y;
        if(transform.position.x > _cameraBounds.max.x)
        {
            dx = _cameraBounds.min.x;
        }
        if (transform.position.y > _cameraBounds.max.y)
        {
            dy = _cameraBounds.min.y ;
        }
        if (transform.position.x < _cameraBounds.min.x)
        {
            dx = _cameraBounds.max.x ;
        }
        if (transform.position.y < _cameraBounds.min.y)
        {
            dy = _cameraBounds.max.y;
        }
        transform.position = new Vector2(dx,  dy);
    }
}
