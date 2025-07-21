using UnityEngine;
using UnityEngine.XR;

public class BringerOfDeathMovement : MonoBehaviour
{
    public float speed = 5;
    public float attackRange = 1;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    public float attackCooldownTimer;
    private int facingDirection = -1;
    private EnemyState enemyState;

    public Rigidbody2D rb;
    public Transform player;
    private Animator animator;


    public TutorialMenuController tutorialMenuController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    void Chase()
    {
        if (player.position.x > transform.position.x && facingDirection == -1
               || player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        if (hits.Length > 0)
        {
            player = hits[0].transform;
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
            animator.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            animator.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            animator.SetBool("isAttacking", false);

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
            animator.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
        {
            if (tutorialMenuController != null)
            tutorialMenuController.SetText("EnemyChase", "The torch is trying to attack you, press Enter to attack.");
            animator.SetBool("isChasing", true);
        }
        else if (enemyState == EnemyState.Attacking)
            animator.SetBool("isAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}

