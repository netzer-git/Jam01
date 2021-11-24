
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{

    [SerializeField] private int bricksNum;
    private float brickAddCooldown = 0f;

    [SerializeField] GameObject regBrickPref;
    [SerializeField] GameObject ballBrickPref;
    [SerializeField] GameObject speedBrickPref;


    // Start is called before the first frame update
    void Start()
    {
        bricksNum = 5; // TODO: update
    }

    // Update is called once per frame
    void Update()
    {
        brickAddCooldown += 1 * Time.deltaTime;
        if (brickAddCooldown > 5 && bricksNum < 8)
        {
            SpawnNewBrick();
            brickAddCooldown = 0;
        }
    }

    public void DecreaseBricksNum()
    {
        bricksNum--;
    }

    private void SpawnNewBrick()
    {
        bricksNum++;
        bool inColl = true;
        Vector2 pos = Vector2.one;
        while (inColl)
        {
            pos = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            Vector2 posPlusX = new Vector2(pos.x + 0.5f, pos.y);
            Vector2 posMinusX = new Vector2(pos.x - 0.5f, pos.y);
            Vector2 posPlusY = new Vector2(pos.x, pos.y + 1.5f);
            Vector2 posMinusY = new Vector2(pos.x, pos.y - 1.5f);
            bool inCollider = !CheckPositionInsideCollider(posPlusX) && !CheckPositionInsideCollider(posMinusX) && !CheckPositionInsideCollider(posPlusY) && !CheckPositionInsideCollider(posMinusY);
            if (inCollider)
            {
                inColl = false;
            }
        }
        int brickIndex = Random.Range(1, 10);
        if (brickIndex > 7)
        {
            Instantiate(ballBrickPref, pos, Quaternion.identity);
        }
        else if (brickIndex > 6)
        {
            Instantiate(speedBrickPref, pos, Quaternion.identity);
        }
        else
        {
            Instantiate(regBrickPref, pos, Quaternion.identity);
        }
        Debug.Log("new brick in " + pos.ToString());
    }

    private bool CheckPositionInsideCollider(Vector2 pos)
    {
        return Physics2D.OverlapCircleAll(pos, 0.0f).Length > 0 ? true : false;
    }
}
