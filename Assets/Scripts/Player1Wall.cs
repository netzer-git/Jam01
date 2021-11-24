using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Wall : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        animator.SetTrigger("goal");
    }
}
