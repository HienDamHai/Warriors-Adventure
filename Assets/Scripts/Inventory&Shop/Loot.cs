using System;
using UnityEngine;


public class Loot : MonoBehaviour
{
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim; 

    public bool canBePickedUp = true; // If false, the item cannot be picked up
    public int quantity = 1;
    public static event Action<ItemSO, int> OnItemLooted;

    void OnValidate()
    {
        if (itemSO == null) return;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canBePickedUp == true)
        {
            anim.Play("LootPickup");
            OnItemLooted?.Invoke(itemSO, quantity);
            Destroy(gameObject, 0.5f); // Destroy after animation plays
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canBePickedUp = true;
        }
    }

    public void UpdateApperance()
    {
        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;
    }

    public void Initialize(ItemSO itemSO, int quantity)
    {
        this.itemSO = itemSO;
        this.quantity = quantity;
        canBePickedUp = false;
        UpdateApperance();
    }





}