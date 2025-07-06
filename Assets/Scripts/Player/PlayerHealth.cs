using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private static PlayerHealth _instance; // Biến tĩnh để lưu Instance duy nhất của PlayerHealth

    public TMP_Text textHealth; // TextMeshPro để hiển thị máu

    private float invicibleTime = 0;
    public float invicibleCooldown = 2f; // Thời gian bất tử sau khi bị thương
    public static PlayerHealth Instance;
    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth; // Khởi tạo máu hiện tại bằng máu tối đa
        if (textHealth != null)
        {
            textHealth.text = $"HP: {StatsManager.Instance.currentHealth}/{StatsManager.Instance.maxHealth}"; // Hiển thị máu ban đầu
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
            textHealth.text = $"HP: {StatsManager.Instance.currentHealth}/{StatsManager.Instance.maxHealth}"; // Cập nhật hiển thị máu
            // Có thể thêm hiệu ứng hình ảnh hoặc âm thanh khi bị thương
            // Debug.Log("Player took damage! Current Health: " + currentHealth);
        }
        else if (amount > 0)
        {
            StatsManager.Instance.currentHealth += amount; // Tăng máu hiện tại
            StatsManager.Instance.currentHealth = Mathf.Clamp(StatsManager.Instance.currentHealth, 0, StatsManager.Instance.maxHealth); // Đảm bảo máu không vượt quá giới hạn
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
            Debug.Log("Health: " + StatsManager.Instance.currentHealth);
            Debug.Log("Invicible Time: " + invicibleTime);
        }
    }
}
