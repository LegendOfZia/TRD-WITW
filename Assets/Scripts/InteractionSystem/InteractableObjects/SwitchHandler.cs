using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandler : InteractableObject
{
    public GameObject stick;
    /*public List<GameObject> targetObjs;
    private List<InteractableObject> targetInteracts;*/

    public void Start()
    {

    }

    public override void Toggle()
    {
        base.Toggle();
        Vector3 tmpPos = stick.transform.localPosition;
        if (_switched == true)
        {
            tmpPos.z = -0.08f;
        }
        else
        {
            tmpPos.z = 0.08f;
        }
        stick.transform.localPosition = tmpPos;

    }
}
