using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint; // Điểm tấn công, nơi sẽ phát ra đòn tấn công
    public LayerMask enemyLayer; // Lớp đối tượng kẻ thù để phát hiện va chạm

    public AudioClip attackClip;


    public static PlayerCombat Instance; // Biến tĩnh để lưu Instance duy nhất của PlayerCombat
    public Animator animator; // Animator để điều khiển các hoạt ảnh tấn công
    public float attackCooldown = 1f; // Thời gian hồi chiêu giữa các đòn tấn công

    [HideInInspector]
    public float timer = 0f; // Biến để theo dõi thời gian hồi chiêu

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

        timer = GetRealCooldown();
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
        SFXManager.Instance.PlaySFX(attackClip, transform, 1f);
        animator.SetBool("IsAttacking", true); // Kích hoạt hoạt ảnh tấn công
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false); // Kết thúc hoạt ảnh tấn công
        timer = GetRealCooldown();
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.weaponRange, enemyLayer); // Lấy tất cả kẻ thù trong phạm vi tấn công
        if (enemies.Length > 0)
        {
            Collider2D enemy = null; 
            //Check enemy gần nhất
            float closestDistance = Mathf.Infinity;
            foreach (Collider2D e in enemies)
            {
                float distance = Vector2.Distance(attackPoint.position, e.transform.position);
                if (distance < closestDistance && distance < StatsManager.Instance.weaponRange) // Chỉ chọn kẻ thù trong phạm vi tấn công
                {
                    closestDistance = distance;
                    enemy = e;
                }
            }

            
            if (enemy == null) return; // Nếu không có kẻ thù nào trong phạm vi tấn công, thoát khỏi phương thức
            enemy.GetComponent<Enemy_Health>().ChangeHealth(-StatsManager.Instance.damage); // Gọi phương thức TakeDamage trên kẻ thù đầu tiên

            if (enemy.GetComponent<Torch_Knockback>() != null)
            {
                enemy.GetComponent<Torch_Knockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime); // Gọi phương thức Knockback trên kẻ thù đầu tiên
            }
            else if (enemy.GetComponent<Lancer_Knockback>() != null)
            {
                enemy.GetComponent<Lancer_Knockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime); // Gọi phương thức Knockback trên kẻ thù đầu tiên
            }
            else if (enemy.GetComponent<ThiefKnockback>() != null)
            {
                enemy.GetComponent<ThiefKnockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime); // Gọi phương thức Knockback trên kẻ thù đầu tiên
            }
            else if (enemy.GetComponent<BringerOfDeathKnockback>() != null)
            {
                enemy.GetComponent<BringerOfDeathKnockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime); // Gọi phương thức Knockback trên kẻ thù đầu tiên
            }

        }
    }
    private float GetRealCooldown()
    {
        float speed = StatsManager.Instance.attackSpeed;
        return attackCooldown / Mathf.Max(speed, 0.1f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Màu sắc của Gizmos
        Gizmos.DrawWireSphere(attackPoint.position, 1f); // Vẽ hình cầu xung quanh điểm tấn công
    }
}
