using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTriggerObjHandler : InteractableObject
{
    public GameObject trueLoc;
    public GameObject falseLoc;
    private Transform trueTrn;
    private Transform falseTrn;

    private void Start()
    {
        trueTrn = trueLoc.GetComponent<Transform>();
        falseTrn = falseLoc.GetComponent<Transform>();
    }

    public override void Toggle()
    {
        base.Toggle();
        if(Switched)
        {
            transform.position = trueTrn.position;
            transform.rotation = trueTrn.rotation;
            transform.localScale = trueTrn.localScale;
        } else
        {
            transform.position = falseTrn.position;
            transform.rotation = falseTrn.rotation;
            transform.localScale = falseTrn.localScale;
        }
    }
}
