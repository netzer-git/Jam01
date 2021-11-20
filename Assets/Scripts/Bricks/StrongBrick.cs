using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : BrickManager
{
    private int strength = 2;
    protected override void BrickBehavior(int playerID , BallManager bm){
        strength--;
        if (strength == 0){
            Destroy(gameObject);
        }
   
    }
}
