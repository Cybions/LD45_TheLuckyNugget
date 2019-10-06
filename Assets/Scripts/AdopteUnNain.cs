using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdopteUnNain : MonoBehaviour
{
    [SerializeField]
    private Dwarf dwarf;

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
        Itembtn.interactable = (GameManager.Instance.playerGold >= dwarf.Cost);
    }

    public void WritePrice()
    {
        if (isLocked) { return; }
        if (isBought) { tmpPrice.text = "Hired"; return; }
        tmpPrice.text = dwarf.Cost.ToString();
    }

    public void BuyItem()
    {
        GameManager.Instance.ChangeAmountOfGold(dwarf.Cost);
        DwarvesManager.Instance.SpawnLordHitnrun(dwarf);
        isBought = true;
        DwarvesManager.Instance.SetLockedAxes();
    }
}
