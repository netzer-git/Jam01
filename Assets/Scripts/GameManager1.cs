using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    [SerializeField] private int player1Score = 0;
    [SerializeField] private int player2Score = 0;
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;
    // [SerializeField] private LifeMeterManager player1Life;
    // [SerializeField] private LifeMeterManager player2Life;

    [SerializeField] private GameObject player1ShootPoint;
    [SerializeField] private GameObject player2ShootPoint;

    // TODO: temporary
    [SerializeField] private Canvas winCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // start time (in case of pause)

        player1ScoreText.text = scoreToString(player1Score);
        player2ScoreText.text = scoreToString(player2Score);
    }

    // Update is called once per frame
    void Update()
    {
        // check for game's end 
        if (player1Score == 5)
        {
            EndLevel(1);
        }
        else if (player2Score == 5)
        {
            EndLevel(2);
        }

        //if (player1Life.GetRemainingLife() == 0)
        //{
            // first phase of the game ends
        //}
        //else if (player2Life.GetRemainingLife() == 0)
        //{
            // player 2 lose / player 1 win
        //}


        // FIXME: restart game - Test case helper
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
        //Debug.Log("Red's score: " + redScore + ", Blue's score: " + blueScore);
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

    /**
     * finish the current level
     */
    private void EndLevel(int winnerID)
    {
        Time.timeScale = 0; // stop the level - if we have another one, probably need to start it again
        winCanvas.gameObject.SetActive(true);
        winCanvas.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Player " + winnerID + " has won!";
    }
}
