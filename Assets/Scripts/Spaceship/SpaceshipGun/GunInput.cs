using UnityEngine;

public class SpaceshipGunInput : IGunInput
{
    private bool _isFire = false;
    public bool IsFire => _isFire;


    public void ReadInput()
    {
        _isFire = Input.GetButtonDown("Fire1");
    }
}
