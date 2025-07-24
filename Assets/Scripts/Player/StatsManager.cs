using System;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    // public TMP_Text healthText;
    private ProgressBar healthBar;

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

    public event Action<int> HealthUpdatedHandler;
    public event Action<int> MaxHealthUpdatedHandler;
    private int baseDamage;
    private float baseWeaponRange;
    private float baseKnockbackForce;
    private float baseKnockbackTime;
    private float baseStunTime;
    private float baseAttackSpeed;
    private float baseSpeed;
    private int baseMaxHealth;
    void Start()
    {
        baseDamage = damage;
        baseWeaponRange = weaponRange;
        baseKnockbackForce = knockbackForce;
        baseKnockbackTime = knockbackTime;
        baseStunTime = stunTime;
        baseAttackSpeed = attackSpeed;
        baseSpeed = speed;
        baseMaxHealth = maxHealth;
        currentHealth = maxHealth;

        healthBar = FindFirstObjectByType<ProgressBar>();
    }

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
        UpdateHealthBar();
        MaxHealthUpdatedHandler?.Invoke(maxHealth);
        HealthUpdatedHandler?.Invoke(currentHealth);
        // healthText.text = "HP " + currentHealth + "/" + maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if (healthBar != null)
        {
            healthBar.BarValue = currentHealth;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            HealthUpdatedHandler?.Invoke(currentHealth);
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
    public void ResetStats()
    {
        damage = baseDamage;
        weaponRange = baseWeaponRange;
        knockbackForce = baseKnockbackForce;
        knockbackTime = baseKnockbackTime;
        stunTime = baseStunTime;
        attackSpeed = baseAttackSpeed;
        speed = baseSpeed;
        maxHealth = baseMaxHealth;
        currentHealth = maxHealth;

        MaxHealthUpdatedHandler?.Invoke(maxHealth);
        HealthUpdatedHandler?.Invoke(currentHealth);

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.MaxBarValue = maxHealth;
            healthBar.BarValue = currentHealth;
        }
        else
        {
            Debug.LogWarning("Health bar is not assigned in the inspector.");
        }
    }

}
