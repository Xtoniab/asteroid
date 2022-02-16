using UnityEngine;

public interface IAsteroidGenerator
{
    void GenAsteroids(int count); // Генерация определённого кол-ва астероидов
    void GenAsteroid(Vector2 pos, Vector2 scale, float rotation); // Генерация одного астероида
}