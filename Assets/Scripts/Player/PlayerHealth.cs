using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public ProgressBar health;

    public Animator animator;

    private PlayerMovement playerMovement;

    public int live = 3; // Số mạng của người chơi

    private float invicibleTime = 0;
    public float invicibleCooldown = 2f; // Thời gian bất tử sau khi bị thương

    public Action<int> OnHealthUpdated;
    public Action<int> OnMaxHealthUpdated;

    private void Awake()
    {
        OnHealthUpdated = (health) => { 
            this.health.BarValue = health;
        };
        OnMaxHealthUpdated = (maxHealth) =>
        {
            this.health.MaxBarValue = maxHealth;
        };
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth; // Khởi tạo máu hiện tại bằng máu tối đa
        StatsManager.Instance.HealthUpdatedHandler += OnHealthUpdated;
        StatsManager.Instance.MaxHealthUpdatedHandler += OnMaxHealthUpdated;
        if (health != null)
        {
            health.BarValue = StatsManager.Instance.currentHealth;
        }
        else
        {
            Debug.LogWarning("TextMeshPro textHealth is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        InvicibleUpdate(); // Cập nhật thời gian bất tử
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0 && !IsInvicible())
        {
            StatsManager.Instance.currentHealth += amount; // Thay đổi máu hiện tại
            StatsManager.Instance.currentHealth = Mathf.Clamp(StatsManager.Instance.currentHealth, 0, StatsManager.Instance.maxHealth); // Đảm bảo máu không vượt quá giới hạn
            invicibleTime = invicibleCooldown; // Đặt lại thời gian bất tử
            health.BarValue = StatsManager.Instance.currentHealth;
            // Có thể thêm hiệu ứng hình ảnh hoặc âm thanh khi bị thương
            // Debug.Log("Player took damage! Current Health: " + currentHealth);
            if (StatsManager.Instance.currentHealth <= 0)
            {
                gameObject.layer = LayerMask.NameToLayer("Dead");
                // Xử lý khi người chơi chết
                Debug.Log("Player is dead!");
                animator.Play("Death"); // Kích hoạt hoạt ảnh chết
            }


        }
        else if (amount > 0)
        {
            StatsManager.Instance.currentHealth += amount; // Tăng máu hiện tại
            StatsManager.Instance.currentHealth = Mathf.Clamp(StatsManager.Instance.currentHealth, 0, StatsManager.Instance.maxHealth); // Đảm bảo máu không vượt quá giới hạn
            health.BarValue = StatsManager.Instance.currentHealth;
            // Debug.Log("Player healed! Current Health: " + currentHealth);
        }
    }

    bool IsInvicible()
    {
        return invicibleTime > 0; // Trả về true nếu vẫn đang trong thời gian bất tử
    }

    void InvicibleUpdate()
    {
        if (invicibleTime > 0)
        {
            invicibleTime -= Time.deltaTime; // Giảm thời gian bất tử
        }
    }


    public void ResetHealth()
    {
        if (live > 1)
        {
            gameObject.layer = LayerMask.NameToLayer("Player"); // Đặt layer của người chơi thành Player
            live--; // Giảm số mạng khi máu bằng 0
            StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth; // Đặt lại máu hiện tại về máu tối đa
            health.BarValue = StatsManager.Instance.currentHealth; // Cập nhật thanh máu
            invicibleTime = 0; // Đặt lại thời gian bất tử
            animator.Play("Idle"); // Kích hoạt hoạt ảnh đứng yên 
            var LastPosition = CheckpointManager.Instance.LastPosition;
            playerMovement.SetMove(LastPosition);
        }
        else if (live == 1)
        {
            live--; // Giảm số mạng khi máu bằng 0
            gameObject.layer = LayerMask.NameToLayer("Dead"); // Đặt layer của người chơi thành Dead
            playerMovement.DisableInput();
        }

        
    }

}
