using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MineManager : MonoBehaviour
{
    public static MineManager Instance;
    [SerializeField]
    private TextMeshProUGUI TextPrefab;
    [SerializeField]
    private Transform SpawnPosition;
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private Transform ParentCanvas;
    [SerializeField]
    private SoundManager sm;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        if(Camera.main)
            ParentCanvas.DOLookAt(Camera.main.transform.position, 0);
    }

    public void ClickOnTheMine()
    {
        SetNewText();
        sm.PlayMineSound();
        GameManager.Instance.ClickAmount++;
    }

    private void SetNewText()
    {
        float newGold = GameManager.Instance.CurrentPickaxe.Efficiency * 5f;
        GameManager.Instance.EearnGoldWithoutAnim(newGold);
        TextMeshProUGUI spawn = Instantiate(TextPrefab, ParentCanvas);
        spawn.transform.DOMove(SpawnPosition.position, 0);
        Destroy(spawn.gameObject, .9f);
        
        spawn.text = "+" + ExtremeValueResolver.Instance.GetValueResolved(newGold);
        spawn.transform.DOMove(destination.position, .8f);
    }

    public void MinerNewText(float amount)
    {
        sm.PlayMineSound();
        float newGold = amount;
        GameManager.Instance.EearnGoldWithoutAnim(newGold);
        TextMeshProUGUI spawn = Instantiate(TextPrefab, ParentCanvas);
        spawn.transform.DOMove(SpawnPosition.position, 0);
        Destroy(spawn.gameObject, .9f);

        spawn.text = "+" + ExtremeValueResolver.Instance.GetValueResolved(newGold);
        spawn.transform.DOMove(destination.position, .8f);
    }
}
