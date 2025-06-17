using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển của kẻ thù
    public bool isChasingPlayer = false; // Biến để xác định xem kẻ thù có đang đuổi theo người chơi hay không

    private Rigidbody2D rb; // Biến để lưu Rigidbody2D của kẻ thù
    public Transform player; // Biến để lưu vị trí mục tiêu (ví dụ: vị trí của người chơi)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Lấy Rigidbody2D của kẻ thù
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if (isChasingPlayer)
        {
            if (player != null)
            {
                Vector2 direction = (player.position - transform.position).normalized; // Tính hướng di chuyển về phía người chơi
                rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime); // Di chuyển kẻ thù về phía người chơi
            }
        } // Nếu không đuổi theo người chơi hoặc không có người chơi, thoát hàm

    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         isChasingPlayer = true; // Bắt đầu đuổi theo người chơi khi va chạm
    //     }

    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     isChasingPlayer = false; // Dừng đuổi theo người chơi khi rời khỏi vùng va chạm
    // }
}
