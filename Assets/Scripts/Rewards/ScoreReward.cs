using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReward : IReward
{
    private int _count;
    public ScoreReward(int count)
    {
        _count = count;
    }
    public void GiveReward()
    {
        GameController.Instance.AddScore(_count);
    }

}
