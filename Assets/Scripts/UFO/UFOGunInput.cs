using UnityEngine;

public class UFOGunInput : IGunInput
{
    private bool _isFire = false;
    public bool IsFire => _isFire;

    private float _timeBeforeShot = 0f;

    public void ReadInput()
    {
        _timeBeforeShot -= Time.deltaTime;
        if(_timeBeforeShot <= 0)
        {
            _isFire = true;
            _timeBeforeShot = Random.Range(1f,3f);
        }
        else
        {
            _isFire = false;
        }
        
    }
}
