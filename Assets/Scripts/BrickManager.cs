using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (collision.gameObject.tag == "Ball"){
            Destroy(gameObject);    
        }
        
    }

}
