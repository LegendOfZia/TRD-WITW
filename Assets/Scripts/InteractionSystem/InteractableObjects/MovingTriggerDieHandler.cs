using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTriggerDieHandler : InteractableObject
{
    public GameObject trueLoc;
    public GameObject falseLoc;
    private Vector3 truePos;
    private Vector3 falsePos;

    private void Start()
    {
        truePos = trueLoc.GetComponent<Transform>().position;
        falsePos = falseLoc.GetComponent<Transform>().position;
    }

    public override void Toggle()
    {
        base.Toggle();
        if(Switched)
        {
            transform.position = truePos;
        } else
        {
            transform.position = falsePos;
        }
    }
}
