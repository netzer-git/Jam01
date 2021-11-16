using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private int wallOwner;
    [SerializeField] private LifeMeterManager lifeMeter;
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
        if (col.gameObject.tag == "RedBall" && wallOwner == 1)
        {
            lifeMeter.DecreaseLife();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "BlueBall" && wallOwner == 1)
        {
            gameManager.AddScore(2, 10);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "RedBall" && wallOwner == 2)
        {
            gameManager.AddScore(1, 10);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "BlueBall" && wallOwner == 2)
        {
            lifeMeter.DecreaseLife();
            Destroy(col.gameObject);
        }

    }
}
