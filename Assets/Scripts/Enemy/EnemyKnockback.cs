using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D component for physics interactions


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized; // Calculate the direction away from the player
        rb.linearVelocity = direction * knockbackForce; // Apply the knockback force to the Rigidbody2D
        Debug.Log("Knockback applied to " + gameObject.name + " with force: " + knockbackForce);
    }
    


}
