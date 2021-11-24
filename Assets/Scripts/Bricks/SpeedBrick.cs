using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBrick : BrickManager
{
    public float speedFactor = 1.5f;
    protected override void BrickBehavior(int playerID, BallManager bm){
        bm.startVelocity = speedFactor * bm.startVelocity;
        bm.constVelocity = speedFactor * bm.constVelocity;
        Destroy(gameObject);   
    }
}
