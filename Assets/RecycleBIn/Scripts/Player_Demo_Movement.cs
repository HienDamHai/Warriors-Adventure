using UnityEngine;

public class Player_Demo_Movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
