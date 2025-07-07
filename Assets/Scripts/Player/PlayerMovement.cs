using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction attackAction; // Thêm InputAction cho tấn công
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 move;
    private Vector2 moveDirection = Vector2.down; // Hướng di chuyển của nhân vật
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true; // Biến để theo dõi hướng của nhân vật
    private PlayerCombat playerCombat; // Biến để lưu PlayerCombat

    private bool isKnockback;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable(); // Kích hoạt InputAction
        attackAction.Enable(); // Kích hoạt InputAction cho tấn công
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCombat = PlayerCombat.Instance; // Lấy Instance của PlayerCombat
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
        if (!isKnockback)
        {
            Vector2 position = (Vector2)rb.position + move * StatsManager.Instance.speed * Time.deltaTime;
            rb.MovePosition(position);
        }
        OnAttack();
    }

    void Flip()
    {
        if (move.x > 0.01 && !isFacingRight || move.x < -0.01 && isFacingRight)
        {
            isFacingRight = !isFacingRight; // Đảo ngược hướng
            spriteRenderer.flipX = !spriteRenderer.flipX; // Lật hình ảnh của nhân vật
        }
    }

    void OnAttack()
    {
        if (playerCombat != null && attackAction.IsPressed())
        {
            if (playerCombat.timer <= 0)
            {
                playerCombat.Attack(); // Gọi hàm tấn công từ PlayerCombat
            }

        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         PlayerHealth.Instance.ChangeHealth(-10f); // Giảm máu khi va chạm với kẻ thù
    //         Debug.Log("Player collided with enemy! Current Health: " + PlayerHealth.Instance.currentHealth);
    //     }
    // }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockback = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockback = false;
    }
}
