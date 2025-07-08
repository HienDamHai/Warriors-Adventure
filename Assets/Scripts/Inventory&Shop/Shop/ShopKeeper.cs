using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{

    public static ShopKeeper currentShopKeeper;

    public Animator animator;
    public CanvasGroup shopCanvasGroup;
    public ShopManager shopManager;

    [SerializeField]
    private List<ShopItems> shopItems;

    [SerializeField]
    private List<ShopItems> shopWeapons;

    [SerializeField]
    private List<ShopItems> shopArmour;


    public static event Action<ShopManager, bool> OnShopStateChanged;


    private bool playerInRange;
    private bool isShopOpen;

    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (!isShopOpen)
                {
                    Time.timeScale = 0;
                    isShopOpen = true;
                    currentShopKeeper = this; // Set the current shopkeeper
                    OnShopStateChanged?.Invoke(shopManager, true);
                    shopCanvasGroup.alpha = 1;
                    shopCanvasGroup.blocksRaycasts = true;
                    shopCanvasGroup.interactable = true;
                    OpenItemShop(); // Default to item shop on open
                }
                 else
                {
                    Time.timeScale = 1;
                    isShopOpen = false;
                    currentShopKeeper = null; // Clear the current shopkeeper
                    OnShopStateChanged?.Invoke(shopManager, false);
                    shopCanvasGroup.alpha = 0;
                    shopCanvasGroup.blocksRaycasts = false;
                    shopCanvasGroup.interactable = false;
                }
            }


        }
    }

    public void OpenItemShop()
    {
        shopManager.PopulateShopItems(shopItems);
    }

    public void OpenWeaponShop()
    {
        shopManager.PopulateShopItems(shopWeapons);
    }

    public void OpenArmorShop()
    {
        shopManager.PopulateShopItems(shopArmour);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("playerInRange", true);
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("playerInRange", false);
            playerInRange = false;
        }
    }

}
