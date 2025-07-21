using UnityEngine;

public class BringerofDeathCombat : MonoBehaviour
{
    public int damage = 20;
    public Transform attackPoint;
    public float weaponRange;
    public float knockbackForce;
    public LayerMask playerLayer;
    public float stunTime;
    public AudioClip attackSFX;


    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
        }
        SFXManager.Instance.PlaySFX(attackSFX, transform, 1f);
    }
}
