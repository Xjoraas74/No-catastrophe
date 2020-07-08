using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float speedRun;
    private float waitTime;
    public float startWaitTime;
    public float stoppingDistance; //расстояние м.у врагом и игроком
    public Transform[] moveSpots;
    private int randomSpot;
    private Transform target;
       
    bool patrol = false;
    bool angry = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

   
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance && angry == false)
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
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = Random.Range(0, 15);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speedRun * Time.deltaTime);
    }


}
