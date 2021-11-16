using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float mBallSpeed = 500f;
    private float minVelocity = 2;

    [SerializeField] public int playerOwner = 0;

    public Vector2 startVelocity = new Vector2(3f, 3f);

    // Start is called before the first frame update
    void Start()
    {
        if (playerOwner == 2) // BLUE
        {
            startVelocity.x = -startVelocity.x;
        }
        rb.velocity = startVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // in case of the ball getting slower - apply more force.
        if (rb.velocity.magnitude != startVelocity.magnitude)
        {
            float difference = startVelocity.magnitude / rb.velocity.magnitude;
            rb.velocity = difference * rb.velocity;
            if (Mathf.Abs(rb.velocity.x) < minVelocity){
                rb.velocity = new Vector2(rb.velocity.x * 5, rb.velocity.y); 
            }
        }
    }

    public int GetOwner()
    {
        return playerOwner;
    }
}
