using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.ChangeHealth(-10f); // Giảm máu khi va chạm với kẻ thù
            Debug.Log("Player collided with enemy! Current Health: " + PlayerHealth.Instance.currentHealth);
        }
    }
}
