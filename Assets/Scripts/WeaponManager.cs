using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    // public GameObject bulletPref;
    public KeyCode fireKey;

    [SerializeField] private GameObject playerBallPref;
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
    }

    public void createNewBall()
    {
        if (ball == null)
        {
            ball = Instantiate(playerBallPref, firePoint.position, firePoint.rotation);
            ball.transform.SetParent(firePoint);
        }
    }
}
