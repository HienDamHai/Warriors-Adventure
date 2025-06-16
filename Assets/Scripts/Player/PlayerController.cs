using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật
    public InputAction moveAction;
    public Animator animator;



    private Rigidbody2D rb;
    private Vector2 move;
    private Vector2 moveDirection = Vector2.down; // Hướng di chuyển của nhân vật
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true; // Biến để theo dõi hướng của nhân vật




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Kích hoạt InputAction
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>(); // Đọc giá trị di chuyển từ InputAction
        animator.SetBool("IsMoving", move != Vector2.zero); // Kích hoạt animation di chuyển
        Flip(); // Gọi hàm Flip để kiểm tra và thay đổi hướng của nhân vật

    }

    public void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * moveSpeed * Time.deltaTime;
        rb.MovePosition(position);
    }

    void Flip()
    {
        if (move.x > 0.01 && !isFacingRight || move.x < -0.01 && isFacingRight)
        {
            isFacingRight = !isFacingRight; // Đảo ngược hướng
            spriteRenderer.flipX = !spriteRenderer.flipX; // Lật hình ảnh của nhân vật
        }
    }
}
