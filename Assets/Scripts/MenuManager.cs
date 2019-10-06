using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField]
    private TextMeshProUGUI PlayerGoldTxt;

    [SerializeField]
    private Transform OptionMenu;
    [SerializeField]
    private Transform OptionMenuOrigin;
    [SerializeField]
    private Transform OptionMenuDevelopped;
    private Tweener OptionMenuTweener;
    private bool isOMAtOrigin = true;

    [SerializeField]
    private TextMeshProUGUI GoldMovement;
    [SerializeField]
    private Image GoldMovementContainer;
    [SerializeField]
    private Transform GoldMovementContainerOrigin;
    [SerializeField]
    private Transform GoldMovementContainerSpot;
    [SerializeField]
    private Color posText;
    [SerializeField]
    private Color negText;

    [SerializeField]
    private Image LogoSound;
    [SerializeField]
    private Sprite SoundOn;
    [SerializeField]
    private Sprite SoundOff;
    private bool isSoundOn = true;

    [SerializeField]
    private Transform QuitConfirm;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        OptionMenuTweener = OptionMenu.DOMove(OptionMenuOrigin.position, 0);
        GoldMovementContainer.transform.DOMove(GoldMovementContainerOrigin.position, 0);
    }

    private void LateUpdate()
    {
        if(GameManager.Instance.playerGold <= 0) { PlayerGoldTxt.text = "Nothing";  return; }
        PlayerGoldTxt.text = ExtremeValueResolver.Instance.GetValueResolved(GameManager.Instance.playerGold);
    }

    public void MoveOptionMenu()
    {
        if (!OptionMenuTweener.IsPlaying())
        {
            if(isOMAtOrigin)
            {
                OptionMenuTweener = OptionMenu.DOMove(OptionMenuDevelopped.position, .8f).SetEase(Ease.OutBack);
            }
            else
            {
                OptionMenuTweener = OptionMenu.DOMove(OptionMenuOrigin.position, .8f).SetEase(Ease.OutBack);
            }
            isOMAtOrigin = !isOMAtOrigin;
        }
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        if (isSoundOn)
        {
            LogoSound.sprite = SoundOn;
        }
        else
        {
            LogoSound.sprite = SoundOff;
        }
    }

    public void Goldpopup(string value, bool ispositive)
    {
        string textToDisplay = "";
        if (ispositive) { textToDisplay += ("+" + value); GoldMovement.color = posText; } else
        {
            textToDisplay += ("-" + value); GoldMovement.color = negText;
        }
        GoldMovement.text = textToDisplay;
        GoldMovementContainer.transform.DOMove(GoldMovementContainerSpot.position, 1.5f).OnComplete(delegate {
            GoldMovementContainer.DOFade(0, 1f).OnComplete(delegate { GoldMovementContainer.transform.DOMove(GoldMovementContainerOrigin.position, 0); GoldMovementContainer.DOFade(.92f, 0); GoldMovement.DOFade(1, 0); });
            GoldMovement.DOFade(0, 1f);
        });
    }

    public void ToggleQuit(bool openit)
    {
        QuitConfirm.gameObject.SetActive(openit);
    }

}
