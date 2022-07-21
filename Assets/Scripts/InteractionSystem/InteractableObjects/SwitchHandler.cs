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
        /*targetInteracts = new List<InteractableObject>();
        foreach (GameObject obj in targetObjs)
        {
            if (obj.GetComponent<InteractableObject>() != null)
            {
                targetInteracts.Add(obj.GetComponent<InteractableObject>());
            }
            else
            {
                print("Designated target object: " + obj.name + "does not contain an InteractableObject script");
            }
        }*/
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
        /*foreach(InteractableObject inter in targetInteracts)
        {
            inter.Toggle();
        }*/
    }
}
