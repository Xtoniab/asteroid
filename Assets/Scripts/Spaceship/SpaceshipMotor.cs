using UnityEngine;

public enum Direction
{
    UP,
    RIGHT
}

public class SpaceshipMotor
{
    private IShipInput _input;
    private SpaceshipData _data;
    private Rigidbody2D _ship;
    private Direction _direction;

    public SpaceshipMotor(IShipInput input, SpaceshipData data, Rigidbody2D ship, Direction direction) // Инициализируемся
    {
        _input = input;
        _data = data;
        _ship = ship;
        _direction = direction;
        _ship.drag = _data.Drag;
    }
    private Vector3 GetDirection()
    {
        switch (_direction)
        {
            case Direction.UP:
                return _ship.transform.up;
            case Direction.RIGHT:
                return _ship.transform.right;
            default:
                return Vector3.zero;
        }
    }
    private void Move()
    {
        _ship.AddForce(_input.Thrust * GetDirection() * _data.Acceleration);
        if (_ship.velocity.magnitude > _data.MaxSpeed)
        {
            _ship.velocity = Vector2.ClampMagnitude(_ship.velocity, _data.MaxSpeed);
        }
    }
    private void Rotate()
    {
        _ship.rotation -= (_input.Rotation * _data.TurnSpeed);
    }
    public void Tick()
    {
        Move();
        Rotate();
    }


}
