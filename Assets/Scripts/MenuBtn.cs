using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuBtn : MonoBehaviour
{
    [SerializeField]
    private Transform Destination;
    [SerializeField]
    private TextMeshProUGUI textInside;
    private Vector3 Origin;
    Tweener movement;
    Tweener fade;
    private void Start()
    {
        Origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        movement = textInside.transform.DOMove(Origin, 0);
        fade = GetComponent<Button>().image.DOFade(.2f, 0);
    }

    private void OnMouseEnter()
    {
        print("Enter");
        if(fade.IsPlaying() || movement.IsPlaying())
        {
            movement.Kill();
            fade.Kill();
        }
        movement = textInside.transform.DOMove(Destination.position, .3f);
        fade = GetComponent<Button>().image.DOFade(1, .3f);
    }
    private void OnMouseOver()
    {
        print("hi");
    }

    private void OnMouseExit()
    {
        print("Exit");
        if (fade.IsPlaying() || movement.IsPlaying())
        {
            movement.Kill();
            fade.Kill();
        }
        movement = textInside.transform.DOMove(Origin, .3f);
        fade = GetComponent<Button>().image.DOFade(0, .3f);
    }
}
