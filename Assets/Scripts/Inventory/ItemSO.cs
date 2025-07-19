using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;

    [TextArea]
    public string itemDescription;
    public Sprite icon;

    public bool isGold;
    public int stackSize = 3;
    public bool hasKey = false;

    [Header("Stats")]
    public int maxHealth;
    public int currentHealth;
    public int speed;
    public int damage;
    public int exp;

    [Header("For Temporary Items")]
    public float duration;




}
