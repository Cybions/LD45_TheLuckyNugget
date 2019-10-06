using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Nugget : MonoBehaviour
{
    [SerializeField]
    private HoverElement shop;
    private bool ismoving = false;
    public void GetLooted()
    {
        if (ismoving) { return; }
        ismoving = true;
        shop.ChangeHoverState(true);
        ShrinkToDeath();
    }

    private void ShrinkToDeath()
    {
        transform.DOScale(Vector3.zero, .3f).SetEase(Ease.InBack).OnComplete(delegate { Destroy(this.gameObject); });
        GameManager.Instance.LootTheNugget();
    }
}
