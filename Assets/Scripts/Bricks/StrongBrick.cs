using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : BrickManager
{   
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    private int strength = 2;
    protected override void BrickBehavior(int playerID , BallManager bm){
        strength--;
        spriteRenderer.sprite = sprite2;
        if (strength == 0){
            Destroy(gameObject);
        }
   
    }
}
