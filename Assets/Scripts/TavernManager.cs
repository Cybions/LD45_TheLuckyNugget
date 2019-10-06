using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TavernManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI UpgradeText;
    [SerializeField]
    private TextMeshProUGUI RevenueText;
    [SerializeField]
    private List<TavernUpgrade> Upgrades;
    [SerializeField]
    private GameObject LockedWindow;
    [SerializeField]
    private GameObject UnlockedWindow;
    [SerializeField]
    private Transform ParentWindow;
    [SerializeField]
    private Button Upgradebtn;
    [SerializeField]
    private Button Buybtn;
    private bool isOpen = false;

    [SerializeField]
    private float DefaultRevenue;
    [SerializeField]
    private float CurrentUpgrade = 1;

    bool TarvernIsNotBought = true;

    // Start is called before the first frame update
    void Start()
    {
        LockedWindow.SetActive(true);
        UnlockedWindow.SetActive(false);
        ParentWindow.gameObject.SetActive(false);
    }

    public void ToggleShop()
    {
        ChangeShopStatus(!isOpen);
    }

    public void ChangeShopStatus(bool openIt)
    {
        ParentWindow.gameObject.SetActive(openIt);
    }

    private void LateUpdate()
    {
        float gold = GameManager.Instance.playerGold;
        if (TarvernIsNotBought)
        {
            Buybtn.interactable = gold >= 800;
        }
        Upgradebtn.interactable = gold >= (FindNextUpgrade() / 1.5f);
    }

    private float FindNextUpgrade()
    {
        float result = (CurrentUpgrade + DefaultRevenue) * 2;
        return Mathf.Round(result);
        //bool isNextOne = false;
        //foreach(TavernUpgrade tu in Upgrades)
        //{
        //    if (isNextOne) { return tu; }
        //    if(tu.Cost == CurrentUpgrade.Cost)
        //    {
        //        isNextOne = true;
        //    }
        //}
        //Debug.LogError("UPGRADE NOT FOUND !!");
        //return null;
    }

    public void BuyTheTavern()
    {
        StartCoroutine(TavernRevenue());
        LockedWindow.SetActive(false);
        UnlockedWindow.SetActive(true);
        GameManager.Instance.ChangeAmountOfGold(800);

        UpgradeText.text = ExtremeValueResolver.Instance.GetValueResolved(Mathf.Round(FindNextUpgrade()/1.5f));
        RevenueText.text = ExtremeValueResolver.Instance.GetValueResolved(Mathf.Round(FindNextUpgrade())) + " gold";
    }

    public void UpgradeTavern()
    {
        GameManager.Instance.ChangeAmountOfGold(Mathf.Round(FindNextUpgrade() / 1.5f));
        CurrentUpgrade = FindNextUpgrade();
        UpgradeText.text = ExtremeValueResolver.Instance.GetValueResolved(Mathf.Round(FindNextUpgrade() / 1.5f));
        RevenueText.text = ExtremeValueResolver.Instance.GetValueResolved(Mathf.Round(FindNextUpgrade())) + " gold";
    }

    public void RecruitTavern()
    {

    }

    private IEnumerator TavernRevenue()
    {
        while (GameManager.Instance.isGameRunning)
        {
            yield return new WaitForSeconds(20.0f);
            GameManager.Instance.EearnGold(FindNextUpgrade());
        }
    }
}
