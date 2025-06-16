using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100f; // Máu tối đa của nhân vật
    public float currentHealth; // Máu hiện tại của nhân vật
    public float invicibleTime = 2f; // Thời gian bất tử sau khi bị thương
    public static PlayerHealth Instance; // Biến tĩnh để truy cập từ các lớp khác
    public PlayerHealth()
    {
        Instance = this; // Gán Instance cho đối tượng hiện tại
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // Khởi tạo máu hiện tại bằng máu tối đa
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHealth(float amount)
    {
        if (amount < 0 && invicibleTime > 0) return; // Nếu bị thương và đang trong thời gian bất tử, không thay đổi máu

        currentHealth += amount; // Thay đổi máu hiện tại
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Đảm bảo máu không vượt quá giới hạn

        if (currentHealth <= 0)
        {
            // Die(); // Gọi hàm Die nếu máu bằng 0
        }
    }

}
