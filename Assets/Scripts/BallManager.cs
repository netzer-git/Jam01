using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float mBallSpeed = 500f;

    private Vector2 startVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rb.AddForce(force.normalized * mBallSpeed * Time.deltaTime);
        startVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        // in case of the ball getting slower - apply more force.
        if (rb.velocity.magnitude < startVelocity.magnitude)
        {
            this.rb.AddForce(rb.velocity * Time.deltaTime);
        }
    }
}
