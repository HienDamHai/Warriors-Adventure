using System.Collections;
using UnityEngine;
public class Torch_Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private Torch_Movement torch_Movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torch_Movement = GetComponent<Torch_Movement>();
    }
    public void Knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        torch_Movement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
        Debug.Log("knock");
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        torch_Movement.ChangeState(EnemyState.Idle);
    }
}
