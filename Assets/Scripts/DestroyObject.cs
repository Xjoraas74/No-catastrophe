using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectHitBox;

    void Start()
    {
        objectHitBox.SetActive(true);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerHitBox")
        {
            gameObject.SetActive(false);
            objectHitBox.SetActive(false);
        }
    }
}
