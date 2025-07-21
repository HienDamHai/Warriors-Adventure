using TMPro;
using UnityEngine;

public class InvetoryManager : MonoBehaviour
{

    public InventorySlot[] itemSlots;
    public UseItem useItem;
    public int gold;
    public TMP_Text goldText;
    public GameObject lootPrefab;
    public Transform player;

    void Start()
    {   
        goldText.text = gold.ToString();
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }

    public void UseItem(InventorySlot slot)
    {
        if (slot.itemSO != null && slot.quantity >= 0 && slot.itemSO.hasKey != true)
        {
            useItem.ApplyItemEffect(slot.itemSO);

            slot.quantity--;
            if (slot.quantity <= 0)
            {
                slot.itemSO = null; // Clear the slot if quantity is zero
            }
            slot.UpdateUI();
        }
    }



    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }

    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }


    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }

        foreach (var slot in itemSlots)
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.stackSize)
            {
                int availableSpace = itemSO.stackSize - slot.quantity;
                int amountToAdd = Mathf.Min(quantity, availableSpace);

                slot.quantity += amountToAdd;
                quantity -= amountToAdd;

                slot.UpdateUI();

                if (quantity <= 0)
                {
                    Debug.Log($"Added {amountToAdd} of {itemSO.itemName} to inventory.");
                    return;
                }
            }
        }

        foreach (var slot in itemSlots)
        {

            if (slot.itemSO == null)
            {
                int amountToAdd = Mathf.Min(quantity, itemSO.stackSize);
                slot.itemSO = itemSO;
                slot.quantity = quantity;
                slot.UpdateUI();
                return;
            }

        }

        if (quantity > 0)
        {
            DropLoot(itemSO, quantity);
        }

        Debug.Log($"Added {quantity} of {itemSO.itemName} to inventory.");
    }

    public void DropItem(InventorySlot slot)
    {
        DropLoot(slot.itemSO, 1);
        slot.quantity--;
        if (slot.quantity <= 0)
        {
            slot.itemSO = null;
        }
        slot.UpdateUI();
    }

    private void DropLoot(ItemSO itemSO, int quantity)
    {
        Loot loot = Instantiate(lootPrefab, player.position, Quaternion.identity).GetComponent<Loot>();
        loot.Initialize(itemSO, quantity);
    }

    public bool HasItem(string itemName)
    {
        foreach (var slot in itemSlots)
        {
            if (slot.itemSO != null && slot.itemSO.itemName == itemName && slot.quantity > 0)
            {
                return true;
            }
        }
        return false;
    }
}
