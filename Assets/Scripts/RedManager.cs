using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * player 1 manager - bottom player
 */
public class RedManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private Vector2 direction;

    [SerializeField] private float mPlayerSpeed = 1000f;
    [SerializeField] private float maxBallBOunce = 75f;
    public int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        // this.rb = GetComponent<Rigidbody2D>(); // are we sure we need this?
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float delta = Time.deltaTime * mPlayerSpeed;
            // this.direction = Vector2.left;
            rbPlayer.AddForce(Vector2.up * mPlayerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // this.direction = Vector2.right;
            rbPlayer.AddForce(Vector2.down * mPlayerSpeed * Time.deltaTime);
        }
    }

    /**
     * effects the bouncyness of the paddle - so the ball will jump back according to the place on the paddle
     * try not to maddle with it
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // BallManager ball = collision.gameObject.GetComponent<BallManager>();
        // if (ball != null)
        // {
        //     Vector2 player = this.transform.position;
        //     Vector2 contactPoint = collision.GetContact(0).point;

        //     float offset = player.x - contactPoint.x;
        //     float playerWidth = collision.otherCollider.bounds.size.x / 2;
        //     float angle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
        //     float bounceAngle = (offset / playerWidth) * maxBallBOunce;
        //     float newAngle = Mathf.Clamp(angle + bounceAngle, -maxBallBOunce, maxBallBOunce);
        //     Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
        //     ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        // }
    }
}
