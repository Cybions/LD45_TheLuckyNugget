using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class hoverbtnanim : MonoBehaviour
{
    [SerializeField]
    private Image imgToChange;
    [SerializeField]
    private Color HoverColor;
    private Color originColor;



    private void OnMouseEnter()
    {
        print("YA");
        originColor = imgToChange.color;
        imgToChange.DOColor(HoverColor, .8f);
    }
    private void OnMouseExit()
    {

        print("231658");
        imgToChange.DOColor(originColor, .8f);
    }
}
