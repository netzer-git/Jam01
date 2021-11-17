using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public int redScore = 0;
    public int blueScore = 0;
    public Text scoreText;
    [SerializeField] private LifeMeterManager player1Life;
    [SerializeField] private LifeMeterManager player2Life;

    [SerializeField] private GameObject player1ShootPoint;
    [SerializeField] private GameObject player2ShootPoint;
    // Start is called before the first frame update
    void Start()
    {   
        scoreText.text = "Red: " + redScore + ", Blue: " + blueScore;
    }

    // Update is called once per frame
    void Update()
    {
        // check for game's end
        if (player1Life.GetRemainingLife() == 0)
        {
            // first phase of the game ends
        }
        else if (player2Life.GetRemainingLife() == 0)
        {
            // player 2 lose / player 1 win
        }


        // restart game
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore(int playerID, int pointsToAdd){
        if (playerID == 1)
        { 
            redScore += pointsToAdd;
        }
        else
        {
            blueScore += pointsToAdd;
        }
        scoreText.text = "Red: " + redScore + ", Blue: " + blueScore;
        //Debug.Log("Red's score: " + redScore + ", Blue's score: " + blueScore);
    }

    public void InstantiateNewBall(int playerID)
    {
        if (playerID == 1)
        {
            player1ShootPoint.GetComponent<WeaponManager>().createNewBall();
        }
        else if (playerID == 2)
        {
            player2ShootPoint.GetComponent<WeaponManager>().createNewBall();
        }
        else
        {
            throw new System.Exception("Player ID is invalid");
        }
    }
}
