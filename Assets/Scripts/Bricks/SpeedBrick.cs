using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBrick : BrickManager
{
    public int speedFactor = 2;
    protected override void BrickBehavior(int playerID, BallManager bm){
        bm.startVelocity = speedFactor * bm.startVelocity;
        Destroy(gameObject);   
    }
}
