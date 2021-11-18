using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    public GameManager1 gameManager;
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
           player1 = GameObject.Find("Player1");
           player2 = GameObject.Find("Player2");
           gameManager = FindObjectOfType<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * effects the bouncyness of the paddle - so the ball will jump back according to the place on the paddle
     * try not to maddle with it
     */
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedBall"){
            BrickBehavior(1, collision.gameObject.GetComponent<BallManager>());
    
        }
        else if(collision.gameObject.tag == "BlueBall"){
            BrickBehavior(2, collision.gameObject.GetComponent<BallManager>());
        }
        
    }

    protected virtual void BrickBehavior(int playerID, BallManager bm){
        Destroy(gameObject);
    }
}
