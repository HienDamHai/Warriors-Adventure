using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private static PlayerHealth _instance; // Biến tĩnh để lưu Instance duy nhất của PlayerHealth

    public float maxHealth = 100f; // Máu tối đa của nhân vật
    public float currentHealth = 100f; // Máu hiện tại của nhân vật
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
        currentHealth = maxHealth; // Khởi tạo máu hiện tại bằng máu tối đa
        if (textHealth != null)
        {
            textHealth.text = $"HP: {currentHealth}/{maxHealth}"; // Hiển thị máu ban đầu
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

    public void ChangeHealth(float amount)
    {
        if (amount < 0 && !IsInvicible())
        {
            currentHealth += amount; // Thay đổi máu hiện tại
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Đảm bảo máu không vượt quá giới hạn
            invicibleTime = invicibleCooldown; // Đặt lại thời gian bất tử
            textHealth.text = $"HP: {currentHealth}/{maxHealth}"; // Cập nhật hiển thị máu
            // Có thể thêm hiệu ứng hình ảnh hoặc âm thanh khi bị thương
            // Debug.Log("Player took damage! Current Health: " + currentHealth);
        }
        else if (amount > 0)
        {
            currentHealth += amount; // Tăng máu hiện tại
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Đảm bảo máu không vượt quá giới hạn
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
            Debug.Log("Health: " + currentHealth);
            Debug.Log("Invicible Time: " + invicibleTime);
        }
    }
}
