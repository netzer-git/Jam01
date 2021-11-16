using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float mBallSpeed = 500f;
    [SerializeField] public int playerOwner = 0;

    private Vector2 startVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 force = Vector2.zero;
        force.y = Random.Range(-1f, 1f);
        if (playerOwner == 1) // RED
        {
            force.x = 1f;
        }
        else if (playerOwner == 2) // BLUE
        {
            force.x = -1f;
        }

        this.rb.AddForce(force.normalized * mBallSpeed * Time.deltaTime);
        startVelocity = force.normalized * mBallSpeed * Time.deltaTime;
        // Debug.Log(startVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        // in case of the ball getting slower - apply more force.
        if (rb.velocity.magnitude < startVelocity.magnitude)
        {
            this.rb.AddForce(rb.velocity * Time.deltaTime * 2);
            // Debug.Log("PUSH" + rb.velocity * Time.deltaTime * 2);
        }
    }

    public int GetOwner()
    {
        return playerOwner;
    }
}
