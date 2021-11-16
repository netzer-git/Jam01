using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMeterManager : MonoBehaviour
{
    [SerializeField] private GameObject firstLife;
    [SerializeField] private GameObject secondLife;
    [SerializeField] private GameObject thirdLife;
    private int lifeLeft;
    // Start is called before the first frame update
    void Start()
    {
        lifeLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseLife()
    {
        if (lifeLeft == 3)
        {
            thirdLife.SetActive(false);
        }
        else if (lifeLeft == 2)
        {
            secondLife.SetActive(false);
        }
        else if (lifeLeft == 1)
        {
            firstLife.SetActive(false);
        }
        else if (lifeLeft == 0)
        {
            // if lifeLeft = 0 - end the game
        }
        else
        {
            throw new System.Exception("This amount of life is invalid");
        }
        // decrease life
        lifeLeft -= 1;
    }

    public int GetRemainingLife()
    {
        return lifeLeft;
    }
}
