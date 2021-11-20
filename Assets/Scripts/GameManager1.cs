using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager1 : MonoBehaviour
{
    [SerializeField] private int player1Score = 0;
    [SerializeField] private int player2Score = 0;
    [SerializeField] private int player1NumBalls = 0;
    [SerializeField] private int player2NumBalls = 0;
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;
    [SerializeField] private GameObject player1ShootPoint;
    [SerializeField] private GameObject player2ShootPoint;
    [SerializeField] private Canvas winCanvas;
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1; // start time (in case of pause)
        player1ScoreText.text = scoreToString(player1Score);
        player2ScoreText.text = scoreToString(player2Score);

        InstantiateNewBall(1);
        InstantiateNewBall(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Score == 5)
        {
            EndLevel(1);
        }
        else if (player2Score == 5)
        {
            EndLevel(2);
        }

        Debug.Log(player1NumBalls);



        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddGoal(int playerID, int pointsToAdd){
        if (playerID == 1)
        {
            player1Score += pointsToAdd;
            player1ScoreText.text = scoreToString(player1Score);
        }
        else
        {
            player2Score += pointsToAdd;
            player2ScoreText.text = scoreToString(player2Score);
        }
        Debug.Log("Red's score: " + player1Score + ", Blue's score: " + player2Score);
    }

private static string scoreToString(int score)
    {
        if (score < 10)
        {
            return "00" + score;
        }
        else if (score < 100)
        {
            return "0" + score;
        }
        else if (score < 1_000)
        {
            return score.ToString();
        }
        else
        {
            throw new System.Exception("the Score is too high");
        }
    }

    public void InstantiateNewBall(int playerID)
    {
        if (playerID == 1)
        {
            player1ShootPoint.GetComponent<BallSpawnerScript>().createNewBall();
            player1NumBalls ++;
        }
        else if (playerID == 2)
        {
            player2ShootPoint.GetComponent<BallSpawnerScript>().createNewBall();
            player2NumBalls ++;
        }
        else
        {
            throw new System.Exception("Player ID is invalid");
        }
    }
    public void HandleGoal(int playerID, bool isGoal)
    {
        int winner = isGoal ? playerID : getOtherID(playerID);
        AddGoal(winner, 1);
        if (playerID == 1)
        {
            player1NumBalls--;
            if (player1NumBalls == 0)
            {
                InstantiateNewBall(playerID);
            }
        }
        else if (playerID == 2)
        {
            player2NumBalls--;
            if (player2NumBalls == 0)
            {
                InstantiateNewBall(playerID);
            }
        }
    }


    private int getOtherID(int playerOwner)
    {
        return playerOwner == 1 ? 2 : 1;
    }


    /**
     * finish the current level
     */
    private void EndLevel(int winnerID)
    {
        Time.timeScale = 0; // stop the level - if we have another one, probably need to start it again
        //winCanvas.gameObject.SetActive(true);
        //winCanvas.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Player " + winnerID + " has won!";
    }
}

