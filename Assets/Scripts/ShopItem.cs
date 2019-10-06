using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour     //allo ?
{
    [SerializeField]
    private Pickaxe pickaxe;

    [SerializeField]
    private TextMeshProUGUI tmpPrice;
    [SerializeField]
    private Button Itembtn;

    public bool isBought = false;
    private bool isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        tmpPrice.text = "Locked";
    }

    public void Unlock()
    {
        isLocked = false;
    }

    private void LateUpdate()
    {
        CheckPrice();
        WritePrice();
    }

    public void CheckPrice()
    {
        if (isBought || isLocked) { Itembtn.interactable = false; return; }
        Itembtn.interactable = (GameManager.Instance.playerGold >= pickaxe.PCost);
    }

    public void WritePrice()
    {
        if (isLocked) { return; }
        if (isBought) { tmpPrice.text = "Equiped"; return; }
        tmpPrice.text = pickaxe.PCost.ToString();
    }

    public void BuyItem()
    {
        GameManager.Instance.ChangeAmountOfGold(pickaxe.PCost);
        GameManager.Instance.CurrentPickaxe = this.pickaxe;
        isBought = true;
        ShopManager.Instance.SetLockedAxes();
    }

}
