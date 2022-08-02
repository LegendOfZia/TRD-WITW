using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTriggerObjHandler : InteractableObject
{
    public GameObject onLoc;
    public GameObject offLoc;
    private Transform trueTform;
    private Transform falseTform;

    private void Start()
    {
        trueTform = onLoc.GetComponent<Transform>();
        falseTform = offLoc.GetComponent<Transform>();
    }

    public override void Toggle()
    {
        base.Toggle();
        if(Switched)
        {
            transform.position = trueTform.position;
            transform.rotation = trueTform.rotation;
            transform.localScale = trueTform.localScale;
        } else
        {
            transform.position = falseTform.position;
            transform.rotation = falseTform.rotation;
            transform.localScale = falseTform.localScale;
        }
    }
}
