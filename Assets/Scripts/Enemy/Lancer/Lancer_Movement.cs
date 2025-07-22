using UnityEngine;

public class Lancer_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 1.2f;
    public float attackCooldown = 2f;
    public float playerDetectRange = 5f;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    public AudioClip chaseSFX;

    private float attackCooldownTimer;
    private int facingDirection = 1;
    private EnemyState enemyState;

    public Rigidbody2D rb;
    public Transform player;
    private Animator animator;

    public TutorialMenuController tutorialMenuController;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ChangeState(EnemyState.Idle);
    }

    void Update()
    {
        if (enemyState != EnemyState.Knockback)
        {
            if (attackCooldownTimer > 0)
                attackCooldownTimer -= Time.deltaTime;

            CheckForPlayer();

            if (enemyState == EnemyState.Chasing)
                Chase();
            else if (enemyState == EnemyState.Attacking)
                rb.linearVelocity = Vector2.zero;
        }
    }

    void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        if (hits.Length > 0)
        {
            player = hits[0].transform;
            float distance = Vector2.Distance(transform.position, player.position);
            Vector2 dir = (player.position - transform.position).normalized;

            if (distance <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;

                Vector2 snapped = SnapDirectionTo8(dir);

                // Flip nếu tấn công bên trái/phải
                if (snapped.x < 0 && transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    facingDirection = -1;
                }
                else if (snapped.x > 0 && transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    facingDirection = 1;
                }

                TriggerAttackAnimation(snapped);
                ChangeState(EnemyState.Attacking);
                Invoke(nameof(EndAttack), 1f); // thời gian animation
            }
            else if (distance > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else if (enemyState != EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void Chase()
    {
        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        rb.linearVelocity = dir * speed;

        if ((dir.x > 0 && facingDirection == -1) || (dir.x < 0 && facingDirection == 1))
        {
            Flip();
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void EndAttack()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > attackRange)
            ChangeState(EnemyState.Chasing);
        else
            ChangeState(EnemyState.Idle);
    }

    public void ChangeState(EnemyState newState)
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", false);

        enemyState = newState;

        if (newState == EnemyState.Idle)
            animator.SetBool("isIdle", true);
        else if (newState == EnemyState.Chasing)
        {
            if(tutorialMenuController != null)
                tutorialMenuController.SetText("EnemyChase", "Lancer is chasing you! Avoid its attacks and find a way to defeat it.");
            animator.SetBool("isChasing", true);
            SFXManager.Instance.PlaySFX(chaseSFX, transform, 1f);
        }
        else if (newState == EnemyState.Attacking)
            animator.SetBool("isAttacking", true);
    }

    void TriggerAttackAnimation(Vector2 dir)
    {
        if (dir == new Vector2(0, 1))
        {
            animator.SetTrigger("AttackUp");
        }
        else
        {
            float attackX = dir.x == 0 ? 0 : 1;
            float attackY = dir.y;

            animator.SetFloat("AttackX", attackX);
            animator.SetFloat("AttackY", attackY);
            animator.SetTrigger("Attack");
        }
    }

    Vector2 SnapDirectionTo8(Vector2 dir)
    {
        dir.Normalize();
        Vector2[] directions = new Vector2[]
        {
            new Vector2(0, 1),    // Up
            new Vector2(1, 1),    // UpRight
            new Vector2(1, 0),    // Right
            new Vector2(1, -1),   // DownRight
            new Vector2(0, -1),   // Down
            new Vector2(-1, -1),  // DownLeft
            new Vector2(-1, 0),   // Left
            new Vector2(-1, 1),   // UpLeft
        };

        float maxDot = -Mathf.Infinity;
        Vector2 bestDir = Vector2.zero;

        foreach (Vector2 d in directions)
        {
            float dot = Vector2.Dot(dir, d.normalized);
            if (dot > maxDot)
            {
                maxDot = dot;
                bestDir = d;
            }
        }

        return bestDir;
    }

    void OnDrawGizmosSelected()
    {
        if (detectionPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
        }
    }

}
