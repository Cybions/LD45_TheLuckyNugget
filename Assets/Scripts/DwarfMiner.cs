using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DwarfMiner : MonoBehaviour
{
    private Dwarf dwarf;
    private List<Transform> RoadToHell;
    [SerializeField]
    private MeshRenderer meshHead;
    [SerializeField]
    private MeshRenderer meshBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(Dwarf mystats)
    {
        dwarf = mystats;
        RoadToHell = DwarvesManager.Instance.WayToHell;
        meshHead.material = dwarf.head;
        meshBody.material = dwarf.body;
        StartCoroutine(GoToHell());
    }

    public IEnumerator AutoFarm()
    {
        while (GameManager.Instance.isGameRunning)
        {
            yield return new WaitForSeconds(5);
            MineManager.Instance.MinerNewText(dwarf.Revenue);
        }
    }

    public IEnumerator GoToHell()
    {
        Tweener BloadrickSuck;
        foreach(Transform ts in RoadToHell)
        {
            BloadrickSuck = transform.DOMove(ts.position, GetTimeTravel(ts.position)).SetEase(Ease.Linear);
            transform.DOLookAt(ts.position, .8f);
            yield return new WaitWhile(() => BloadrickSuck.IsPlaying());
        }
        StartCoroutine(AutoFarm());
    }

    public float GetTimeTravel(Vector3 destination)
    {
        return (Vector3.Distance(transform.position, destination)*10)/8.5f;
    }

}
