using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCentipede : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer sprite;

    [SerializeField]
    GameObject attackHitBox;

    public float speed;
    public float speedRun;
    private float waitTime;
    public float startWaitTime;
    public float stoppingDistance; //расстояние м.у врагом и игроком
    public float attackDistance;
    public Transform[] moveSpots;
    private int randomSpot;
    private Transform target;

    bool patrol = false;
    bool angry = false;
    bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

        attackHitBox.SetActive(false);
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance && !angry)
        {
            angry = true;
            patrol = false;
        }

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            patrol = true;
            angry = false;
        }

        if (patrol == true)
        {
            Patrol();
        }
        else if (angry == true)
        {
            Angry();
        }
      //  else if (isAttacking == true)
       // {
           // Attack();
       // }

    }

    void Patrol()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", true);
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = Random.Range(0, 15);
                if ((moveSpots[randomSpot].position.x - transform.position.x) > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
               
                animator.SetBool("isWalking", false);
                waitTime -= Time.deltaTime;
            }
        }
        
    }

    void Angry()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", true);
       
        if ((target.position.x - transform.position.x) > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Vector2.Distance(transform.position, target.position) < attackDistance)
        {
            isAttacking = true;
            attackHitBox.SetActive(true);
            //int choose = 2;
            // int k = 0;
            // while (k == 50)
            // {
            //     choose = UnityEngine.Random.Range(1, 3);
            //      k = 0;
            //  }
            //  animator.Play("Centipede_attack" + choose);

            animator.Play("Centipede_attack1");
            Invoke("ResetAttack", 2f);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speedRun * Time.deltaTime);
        
    }


     void ResetAttack()
    {
         isAttacking = false;
         attackHitBox.SetActive(false);
    }

}
