using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager1 : MonoBehaviour
{
    public int redScore = 0;
    public int blueScore = 0;
    public Text scoreText;
    [SerializeField] private LifeMeterManager player1Life;
    [SerializeField] private LifeMeterManager player2Life;

    [SerializeField] private GameObject redBallPrefab;
    [SerializeField] private GameObject blueBallPrefab;
    [SerializeField] private Transform player1DefaultBallSpawn;
    [SerializeField] private Transform player2DefaultBallSpawn;
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
            Instantiate(redBallPrefab, player1DefaultBallSpawn.position, player1DefaultBallSpawn.rotation);
        }
        else if (playerID == 2)
        {
            Instantiate(blueBallPrefab, player2DefaultBallSpawn.position, player2DefaultBallSpawn.rotation);
        }
        else
        {
            throw new System.Exception("Player ID is invalid");
        }
    }
}
