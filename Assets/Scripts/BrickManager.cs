using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    public GameManager1 gameManager;

    // Start is called before the first frame update
    void Start()
    {
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedBall"){
            gameManager.AddScore(1);
            Destroy(gameObject);    
        }
        else if(collision.gameObject.tag == "BlueBall"){
            gameManager.AddScore(2);
            Destroy(gameObject);
        }
        
    }

}
