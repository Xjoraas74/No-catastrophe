using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;

    public Rigidbody2D rb;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
