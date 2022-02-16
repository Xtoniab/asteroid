using UnityEngine;

public class SimpleAsteroidGenerator : AsteroidGenerator<SimpleAsteroidGenerator>
{
    public override void GenAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GenAsteroid(Vector3.zero, Vector3.one, 0);
        }
    }
}
