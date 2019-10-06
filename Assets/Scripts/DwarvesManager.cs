using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarvesManager : MonoBehaviour
{
    public static DwarvesManager Instance;
    [SerializeField]
    private List<AdopteUnNain> NainList;
    [SerializeField]
    public List<Transform> WayToHell;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        NainList[0].Unlock();
    }

    public void SetLockedAxes()
    {
        bool previousWasbought = true;
        foreach (AdopteUnNain si in NainList)
        {
            if (!si.isBought && previousWasbought) { si.Unlock(); }
            previousWasbought = si.isBought;
        }
    }

    public void SpawnLordHitnrun(Dwarf dwarfToSpawn)
    {
        // -200 IQ be carefull with the dwarf. He can destroy the game  :oo
        GameManager.Instance.EmployeeAmount++;
        DwarfMiner dm = Instantiate(dwarfToSpawn.dwarfMiner);
        dm.transform.parent = null;
        dm.transform.position = WayToHell[0].position;
        dm.Setup(dwarfToSpawn);
    }

}
