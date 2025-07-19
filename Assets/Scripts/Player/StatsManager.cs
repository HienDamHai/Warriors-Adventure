using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    // public TMP_Text healthText;

    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;
    public float attackSpeed;

    [Header("Movement Stats")]
    public float speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        // healthText.text = "HP " + currentHealth + "/" + maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        // healthText.text = "HP " + currentHealth + "/" + maxHealth;
    }

    // public void UpdateSpeed(int amount)
    // {
    //     speed += amount;
    // }

    public void UpdateDamage(int amount)
    {
        damage += amount;
    }

    public void UpdateAttackSpeed(float amount)
    {
        attackSpeed += amount;
    }
    public void UpdateRunSpeed(float amount)
    {
        speed += amount;
    }
}
