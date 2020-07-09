using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    //public float angleOfMovement = .95f;   .61
    public float angleOfMovement;

    Vector2 movement, movementHorizontal, movementVertical;

    void Start()
    {
        movementVertical.x = 0;
        movementHorizontal.y = 0;
    }

    void Update()
    {
        movementHorizontal.x = Input.GetAxisRaw("Horizontal");
        movementVertical.y = Input.GetAxisRaw("Vertical");

        movementVertical = RotateVector(movementVertical, -.95f);
        movementHorizontal = RotateVector(movementHorizontal, -.61f);

        movement = movementVertical + movementHorizontal;

        string y = movementHorizontal + " " + movementVertical + " " + movement;
        Debug.Log(y);
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