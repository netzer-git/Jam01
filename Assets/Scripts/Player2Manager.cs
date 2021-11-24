using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player 2 manager - upper player
 */
public class Player2Manager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private Vector2 direction;

    public KeyCode shotKey;
    [SerializeField] private GameObject player2ShotPref;
    private int shotPressIndex;

    [SerializeField] private float mPlayerSpeed = 1000f;
    [SerializeField] private float maxBallBOunce = 75f;
    public float MIN_HEIGHT;
    public float MAX_HEIGHT;
    public Animator animator;
    public LifeMeterManager lifeMeter;


    // Start is called before the first frame update
    void Start()
    {
        shotPressIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float delta = Time.deltaTime * mPlayerSpeed;
            float newY = Mathf.Clamp(transform.position.y + delta, MIN_HEIGHT, MAX_HEIGHT); 
            transform.position = new Vector3(transform.position.x,newY,transform.position.z); 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float delta = Time.deltaTime * mPlayerSpeed;
            float newY = Mathf.Clamp(transform.position.y - delta, MIN_HEIGHT, MAX_HEIGHT); 
            transform.position = new Vector3(transform.position.x,newY,transform.position.z);
        }
        if (Input.GetKeyDown(shotKey))
        {
            ShootShot();
        }
    }

    /**
     * effects the bouncyness of the paddle - so the ball will jump back according to the place on the paddle
     * try not to maddle with it
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallManager ball = collision.gameObject.GetComponent<BallManager>();
        if (ball != null)
        {
            animator.SetBool("collidedWithBall", true);
            Vector2 player = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = player.y - contactPoint.y;
            float playerWidth = collision.otherCollider.bounds.size.y / 2;
            float angle = Vector2.SignedAngle(Vector2.right, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAngle = (offset / playerWidth) * (-maxBallBOunce);
            float newAngle = Mathf.Clamp(angle + bounceAngle, -maxBallBOunce, maxBallBOunce);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
      
    }


    
    private void OnCollisionStay2D(Collision2D collision){
        BallManager ball = collision.gameObject.GetComponent<BallManager>();
        if (ball != null){
                animator.SetBool("collidedWithBall", true);
        }

    }
    private void OnCollisionExit2D(Collision2D collision){
        animator.SetBool("collidedWithBall", false);
    }


    private void OnTriggerEnter2D(Collider2D collider){
        BulletManager bullet = collider.gameObject.GetComponent<BulletManager>();
        if (bullet != null){
            lifeMeter.DecreaseLife();
        }
    }

    private void ShootShot()
    {
        if (shotPressIndex == 0)
        {
            Transform firePoint = transform.Find("FirePoint2").transform;
            GameObject clone = Instantiate(player2ShotPref, firePoint.position, firePoint.rotation);
            clone.transform.Rotate(0, 0, 90);
            Destroy(clone, 4f);
            clone.transform.SetParent(transform);
            clone.GetComponent<ShotManager>().SetSprite(shotPressIndex);
            shotPressIndex++;
        }
        else if (shotPressIndex > 0 && shotPressIndex <= 5)
        {
            Transform clone = transform.Find("Player2Shot(Clone)");
            clone.GetComponent<ShotManager>().SetSprite(shotPressIndex);
            shotPressIndex++;
        }
        else if (shotPressIndex > 5)
        {
            Transform clone = transform.Find("Player2Shot(Clone)");
            clone.transform.SetParent(null);
            clone.GetComponent<Rigidbody2D>().velocity = Vector2.right * 15;
            shotPressIndex = 0;
        }
    }
}
