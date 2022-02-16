using UnityEngine;

public class ShipInput : IShipInput
{
    private float _rotation = 0;
    private float _thrust = 0;
    public float Rotation => _rotation;
    public float Thrust => _thrust;


    public void ReadInput() // Считываем данные
    {
        _rotation = Input.GetAxis("Horizontal");
        _thrust = Input.GetAxis("Vertical");
        _thrust = _thrust > 0 ? _thrust : 0;
    }
}
