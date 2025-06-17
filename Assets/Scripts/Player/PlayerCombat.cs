using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public static PlayerCombat Instance; // Biến tĩnh để lưu Instance duy nhất của PlayerCombat
    public Animator animator; // Animator để điều khiển các hoạt ảnh tấn công

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

    }

    public void Attack()
    {
        animator.SetBool("IsAttacking", true); // Kích hoạt hoạt ảnh tấn công
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false); // Kết thúc hoạt ảnh tấn công
    }
}
