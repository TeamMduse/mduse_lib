using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Convert : MonoBehaviour
{
    public float Str2Float(string cad)
    {

        string[] CorStr = cad.Split('.');

        float a = float.Parse(CorStr[0]) + float.Parse(CorStr[1]) / (math.pow(10, CorStr[1].Length));

        if (cad.Contains("-")) a = a * -1.0f;

        return a;
    }


    public int3 GetColor(string atomName)
    {
        int3 col = new int3(0, 0, 0);

        foreach (var colval in Colors.AtomColor)
        {
            //print(colval.Key + " >> " + colval.Value);
            if (atomName.Contains(colval.Key)) col = colval.Value;
            
        }

        return col;
    }
}
