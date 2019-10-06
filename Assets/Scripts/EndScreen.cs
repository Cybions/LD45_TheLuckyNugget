using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private Transform screen;
    [SerializeField]
    private Image Deco;
    [SerializeField]
    private TextMeshProUGUI speech;
    [SerializeField]
    private SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        Deco.DOFade(0, 0);
        speech.DOFade(0, 0);
        screen.gameObject.SetActive(false);
    }

    public void StartEndScreen()
    {
        screen.gameObject.SetActive(true);
        sm.PlayEndSong();
        Deco.DOFade(1, 2f).OnComplete(delegate { StartCoroutine(Displaytext()); });
    }

    private IEnumerator Displaytext()
    {
        Tweener izi;
        speech.text = "You've earned " + ExtremeValueResolver.Instance.GetValueResolved(GameManager.Instance.CumulativeGain); speech.DOFade(1, .8f);
        yield return new WaitForSeconds(3f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(()=> izi.IsPlaying());
        speech.text = "You offered a job to " + GameManager.Instance.EmployeeAmount + " people."; speech.DOFade(1, .8f);
        yield return new WaitForSeconds(3f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(() => izi.IsPlaying());
        speech.text = "You mined " + GameManager.Instance.ClickAmount + " times."; speech.DOFade(1, .8f);
        yield return new WaitForSeconds(3f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(() => izi.IsPlaying());
        speech.text = "All your efforts brought you here."; speech.DOFade(1, .8f);
        yield return new WaitForSeconds(3f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(() => izi.IsPlaying());
        speech.text = "Never give up !"; speech.DOFade(1, .8f);
        yield return new WaitForSeconds(2f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(() => izi.IsPlaying());
        speech.text = "Even if you start with nothing."; speech.DOFade(1, .8f);
        yield return new WaitForSeconds(3f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(() => izi.IsPlaying());
        speech.text = "The End"; speech.DOFade(1, .8f);
        yield return new WaitForSeconds(5f);
        Deco.DOFade(0, .8f);
        izi = speech.DOFade(0, .8f);
        yield return new WaitWhile(() => izi.IsPlaying());
        ReturnToMenu();
    }

  
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
