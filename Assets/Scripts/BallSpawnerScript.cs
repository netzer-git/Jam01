using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    // public GameObject bulletPref;
    public KeyCode fireKey;
    
    public GameObject wallToAttack;
    public GameObject wallToDefend;
    [SerializeField] private GameObject playerBallPref;
    //[SerializeField] private GameObject bonusPlayerBallPref;
    private GameObject ball = null;
    void Start()
    {
        createNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey) && ball)
        {
            ball.GetComponent<BallManager>().shootTheBall();
            ball.transform.SetParent(null);
            
            ball = null;
        }
        if (ball)
        {
            ball.transform.position = GetComponentInParent<Transform>().position;
        }
    }

    public void createNewBall()
    {
        if (ball == null)
        {
            ball = Instantiate(playerBallPref, firePoint.position, firePoint.rotation);
            BallManager bm = ball.GetComponent<BallManager>();
            ball.transform.SetParent(firePoint);
            bm.wallToAttack = wallToAttack;
            bm.wallToDefend = wallToDefend;
            //bm.isBonus = isBonus;
        }
    }
}
