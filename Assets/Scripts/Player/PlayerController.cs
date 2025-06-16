using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật
    public InputAction moveAction;


    private Rigidbody2D rb;
    private Vector2 move;
    private Animator animator;
    private Vector2 moveDirection = Vector2.down; // Hướng di chuyển của nhân vật




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Kích hoạt InputAction
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>(); // Đọc giá trị di chuyển từ InputAction
    }

    public void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * moveSpeed * Time.deltaTime;
        rb.MovePosition(position);
    }
}
