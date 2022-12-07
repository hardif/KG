using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] // Á÷·ÄÈ­

public class DataSet
{
    public float[] Pcoord = new float[3];
    public bool[] UIItems = new bool[4];
    public bool[] activeitems = new bool[11];
    public bool[] ghostclear = new bool[3];
    public Vector3[] ghostcoord = new Vector3[3];
    public bool[] ghostactive = new bool[3];

}
