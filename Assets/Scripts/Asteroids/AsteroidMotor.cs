using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMotor
{
    private readonly float _speed;
    private readonly Transform _asteroid;

    public AsteroidMotor(Transform asteroid, float speed)
    {
        _asteroid = asteroid;
        _speed = speed;
    }

    public Asteroid Asteroid
    {
        get => default;
        set
        {
        }
    }

    private void Move()
    {
        _asteroid.Translate(_asteroid.up * _speed / 10f * Time.deltaTime);
    }
    public void Tick()
    {
        Move();
    }
}
