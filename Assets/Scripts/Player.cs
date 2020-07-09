using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2.25f;
    float angleOfMovement = .78f;

    Vector2 movement;

    void Start()
    {
        // past
        if (SceneManager.GetActiveScene().name != "Monsters")
        {
            if (GameObject.Find("Game manager").GetComponent<GameManager>().playerLocationPast != null)
            {
                transform.position = GameObject.Find("Game manager").GetComponent<GameManager>().playerLocationPast.position;
            }
        }

        // future
        else
        {
            if (GameObject.Find("Game manager").GetComponent<GameManager>().playerLocationFuture != null)
            {
                transform.position = GameObject.Find("Game manager").GetComponent<GameManager>().playerLocationFuture.position;
            }
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = RotateVector(movement, -angleOfMovement);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    Vector2 RotateVector(Vector2 v, float angle)
    {
        return new Vector2(
        v.x * Mathf.Cos(angle) - v.y * Mathf.Sin(angle),
        v.x * Mathf.Sin(angle) + v.y * Mathf.Cos(angle)
        );
    }
}