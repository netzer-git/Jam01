using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private int wallOwner;
    // [SerializeField] private LifeMeterManager lifeMeter;
    [SerializeField] private GameManager1 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // TODO: decide who "owns" the balls (maybe the gameManager) - and decide if we need to create more balls

        if (col.gameObject.GetComponent<BallManager>().GetOwner() == 1 && wallOwner == 1)
        {
            // lifeMeter.DecreaseLife();
            gameManager.AddGoal(2, 1);
            Destroy(col.gameObject);
            gameManager.InstantiateNewBall(1);
        }
        else if (col.gameObject.GetComponent<BallManager>().GetOwner() == 2 && wallOwner == 1)
        {
            gameManager.AddGoal(2, 1);
            Destroy(col.gameObject);
            gameManager.InstantiateNewBall(2);
        }
        if (col.gameObject.GetComponent<BallManager>().GetOwner() == 1 && wallOwner == 2)
        {
            gameManager.AddGoal(1, 1);
            Destroy(col.gameObject);
            gameManager.InstantiateNewBall(1);
        }
        else if (col.gameObject.GetComponent<BallManager>().GetOwner() == 2 && wallOwner == 2)
        {
            // lifeMeter.DecreaseLife();
            gameManager.AddGoal(1, 1);
            Destroy(col.gameObject);
            gameManager.InstantiateNewBall(2);
        }
    }
}
