using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager1 : MonoBehaviour
{
    public int redScore = 0;
    public int blueScore = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {   
        scoreText.text = "Red: " + redScore + ", Blue: " + blueScore;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void AddScore(int playerID){
        if (playerID == 1){
            redScore ++;
            
        }
        else{
            blueScore++;
        }
        scoreText.text = "Red: " + redScore + ", Blue: " + blueScore;
        //Debug.Log("Red's score: " + redScore + ", Blue's score: " + blueScore);
    }
}
