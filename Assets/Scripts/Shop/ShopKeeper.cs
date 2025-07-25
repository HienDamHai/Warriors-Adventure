using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopKeeper : MonoBehaviour
{

    public static ShopKeeper currentShopKeeper;

    public Animator animator;
    private Component shopCanvasGroup;

    [SerializeField]
    private List<ShopItems> shopItems;

    [SerializeField]
    private List<ShopItems> shopWeapons;

    [SerializeField]
    private List<ShopItems> shopArmour;


    public static event Action<ShopManager, bool> OnShopStateChanged;

    private bool playerInRange;
    private bool isShopOpen;
    private InputAction InteractAction { get; set; }

    private void Awake()
    {
        InteractAction = InputSystem.actions.FindAction("ToggleShop");
        InteractAction.performed += ctx => UpdateInteraction();
    }

    private void UpdateInteraction()
    {
        if (playerInRange)
        {
            if (!isShopOpen)
            {
                Time.timeScale = 0;
                isShopOpen = true;
                currentShopKeeper = this; // Set the current shopkeeper
                OnShopStateChanged?.Invoke(ShopManager.Instance, true);
                ShopCanvasActiveIfNull();
                shopCanvasGroup.gameObject.SetActive(true);
                OpenItemShop(); // Default to item shop on open
            }
            else
            {
                Time.timeScale = 1;
                isShopOpen = false;
                currentShopKeeper = null; // Clear the current shopkeeper
                OnShopStateChanged?.Invoke(ShopManager.Instance, false);
                ShopCanvasActiveIfNull();
                shopCanvasGroup.gameObject.SetActive(false);
            }
        }
    }

    public void ShopCanvasActiveIfNull()
    {
        if (shopCanvasGroup == null)
        {
            shopCanvasGroup = ShopManager.Instance.shopCanvas;
        }
    }

    public void OpenItemShop()
    {
        ShopManager.Instance.PopulateShopItems(shopItems);
    }

    public void OpenWeaponShop()
    {
        ShopManager.Instance.PopulateShopItems(shopWeapons);
    }

    public void OpenArmorShop()
    {
        ShopManager.Instance.PopulateShopItems(shopArmour);
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
