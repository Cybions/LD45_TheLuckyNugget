using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremeValueResolver : MonoBehaviour
{
    public static ExtremeValueResolver Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public string GetValueResolved(float BigAssValue)
    {
        if (BigAssValue >= 1000000000000)
        {
            return (Mathf.RoundToInt(BigAssValue / 1000000000000) + "Tr");
        }
        if (BigAssValue >= 1000000000)
        {
            return (Mathf.RoundToInt(BigAssValue / 1000000000) + "B");
        }
        if (BigAssValue >= 1000000)
        {
            return (Mathf.RoundToInt(BigAssValue / 1000000) + "M");
        }
        if(BigAssValue >= 1000)
        {
            return (Mathf.RoundToInt(BigAssValue / 1000) + "K");
        }
        return Mathf.RoundToInt(BigAssValue).ToString();
    }

}
