using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    [SerializeField] Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(int index)
    {
        if (index < 0 || index > 5)
        {
            throw new System.Exception("Unkown sprite index");
        }
        else
        {
            SpriteRenderer renderer = (SpriteRenderer) gameObject.GetComponent("SpriteRenderer");
            renderer.sprite = spriteArray[index];
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Destroy(gameObject);
    }
}
