using System;
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
        MaxHealthUpdatedHandler?.Invoke(maxHealth);
        HealthUpdatedHandler?.Invoke(currentHealth);

    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            HealthUpdatedHandler?.Invoke(currentHealth);
        }
        MaxHealthUpdatedHandler?.Invoke(maxHealth);
        HealthUpdatedHandler?.Invoke(currentHealth);
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
    }

}
