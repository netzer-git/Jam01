using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerBrick : BrickManager
{
    protected override void BrickBehavior(int playerID, BallManager bm){
        gameManager.InstantiateNewBall(playerID);
        Destroy(gameObject);   
    }
}
