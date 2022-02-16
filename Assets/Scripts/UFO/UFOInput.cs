using UnityEngine;

public class UFOInput : IShipInput
{
    private float _thrust = 1;
    private float _time = 0f;
    public float Rotation => 0;

    public float Thrust => _thrust;

    public void ReadInput()
    {
        _time -= Time.deltaTime;
        if(_time <= 0)
        {
            _thrust = -_thrust;
            _time = Random.Range(2f, 5f);
        }
    }
}
