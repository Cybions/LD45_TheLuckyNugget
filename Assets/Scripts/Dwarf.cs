using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dwarf", menuName = "TLN/Dwarf", order = 3)]
public class Dwarf : ScriptableObject
{
    public float Cost;
    public float Revenue;
    public DwarfMiner dwarfMiner;
    public Material head;
    public Material body;
}
