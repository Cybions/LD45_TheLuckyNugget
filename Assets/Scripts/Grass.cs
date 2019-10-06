using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Grass : MonoBehaviour
{
    bool ismoving = false;
    public void RemoveGrass()
    {
        if (ismoving) { return; }
        ismoving = true;
        transform.DOScale(Vector3.zero, .8f).SetEase(Ease.InBack).OnComplete(delegate { Destroy(this.gameObject); });
    }

}
