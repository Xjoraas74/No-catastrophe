using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer sprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    private void FixedUpdate()
    {
        animator.SetBool("mask", false);

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moveUp", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moveUp", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moveUp", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moveUp", true);
        }
    }
}
