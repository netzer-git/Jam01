using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancePlayerBrick : BrickManager
{
    protected override void BrickBehavior(int playerID, BallManager bm){
        if (playerID == 1){
            player1.transform.position = player1.transform.position + player1.transform.up;
        }
        if (playerID == 2){
            player2.transform.position = player2.transform.position - player2.transform.up;
        }
        Destroy(gameObject);   
    }
}
