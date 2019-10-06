using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [SerializeField]
    private Transform shopTrans;
    [SerializeField]
    private List<ShopItem> shopItems;
    private bool isOpen = false;
    private Tweener ShopAnim;

    private void Start()
    {
        Instance = this;
        shopTrans.gameObject.SetActive(false);
    }

    public void ToggleShop()
    {
        ChangeShopStatus(!isOpen);
    }

    public void ChangeShopStatus(bool openIt)
    {
        shopTrans.gameObject.SetActive(openIt);
        SetLockedAxes();
    }

    public void SetLockedAxes()
    {
        bool previousWasbought = true;
        foreach(ShopItem si in shopItems)
        {
            if (!si.isBought && previousWasbought) { si.Unlock(); }
            previousWasbought = si.isBought;
        }
    }
}
