using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrimitives : MonoBehaviour
{

    public GameObject CreatePrimitiveUnity(Vector3 ini, Vector3 LookAt, Vector3 scale, PrimitiveType type)
    {

        GameObject model = GameObject.CreatePrimitive(type);
        model.transform.position = ini;
        Transform model_Tran = model.transform;

        if (LookAt != Vector3.zero) model_Tran.LookAt(LookAt);


        if (scale != Vector3.zero) model_Tran.localScale = scale;

        return model;
    }


    public GameObject CreateCilinder(Vector3 ini, Vector3 end, float radio)
    {

        GameObject model = new GameObject();

        return model;
    }

}
