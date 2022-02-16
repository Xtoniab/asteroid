using System.Collections.Generic;
using UnityEngine;


public class RandomPlacedAsteroidGenerator : AsteroidGenerator<RandomPlacedAsteroidGenerator>
{

    private Bounds _cameraBounds;
    
    public override void GenAsteroids(int count)
    {
        _cameraBounds = Camera.main.OrthographicBounds();

        for (int i = 0; i < count; i++)
        {
            float newX = Random.Range(_cameraBounds.min.x, _cameraBounds.max.x);
            float newY = Random.Range(_cameraBounds.min.y, _cameraBounds.max.y);
            Vector2 newPos = new Vector2(newX, newY);
            Vector2 newScale = Vector3.one * _data.StartSize;
            float newRotation = Random.Range(0.0f, 360.0f);
            GenAsteroid(newPos, newScale, newRotation);
        }
    }

}
