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
    public bool[] ghost = new bool[3];
    public float[,] ghostcoord = new float[3, 3];

}
