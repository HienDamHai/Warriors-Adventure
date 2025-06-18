using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint; // Điểm tấn công, nơi sẽ phát ra đòn tấn công
    public float weaponRange; // Phạm vi tấn công của vũ khí
    public LayerMask enemyLayer; // Lớp đối tượng kẻ thù để phát hiện va chạm
    public float knockbackForce = 10f; // Lực đẩy khi tấn công kẻ thù
    public int damage = 1;


    public static PlayerCombat Instance; // Biến tĩnh để lưu Instance duy nhất của PlayerCombat
    public Animator animator; // Animator để điều khiển các hoạt ảnh tấn công
    public float attackCooldown = 1f; // Thời gian hồi chiêu giữa các đòn tấn công


    private float timer = 0f; // Biến để theo dõi thời gian hồi chiêu

    void Awake()
    {
        Instance = this; // Gán Instance cho PlayerCombat
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Lấy Animator từ GameObject nếu chưa được gán
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // Giảm thời gian hồi chiêu
        }
    }

    public void Attack()
    {
        if (timer > 0) return; // Nếu còn thời gian hồi chiêu, không thực hiện tấn công
        animator.SetBool("IsAttacking", true); // Kích hoạt hoạt ảnh tấn công
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false); // Kết thúc hoạt ảnh tấn công
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer); // Lấy tất cả kẻ thù trong phạm vi tấn công
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce); // Gọi phương thức Knockback trên kẻ thù đầu tiên
        }

    }
}
