using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{

    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    [SerializeField]
    public ShopManager shopManager;

    // [SerializeField]
    // public ShopInfo shopInfo;


    public int price;

    public void Initialize(ItemSO newItemSO, int price)
    {
        itemSO = newItemSO;
        itemImage.sprite = itemSO.icon;
        if (itemSO.damage != 0)
        {
            itemNameText.text = "Damage: " + itemSO.damage;
        }
        else
        {
            itemNameText.text = "Healing: " + itemSO.currentHealth;
        }
        this.price = price;
        priceText.text = price.ToString();

    }

    public void OnBuyButtonClicked()
    {
        shopManager.TryBuyItem(itemSO, price);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemSO == null)
        {
            return;
        }
        // shopInfo.ShowItemInfo(itemSO);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        // shopInfo.HideItemInfo();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        // if (itemSO != null)
        // {
        //     shopInfo.FollowMouse();
        // }
    }
}
