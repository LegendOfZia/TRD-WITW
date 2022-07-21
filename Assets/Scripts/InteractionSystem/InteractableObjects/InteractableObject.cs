using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected bool _switched = true;
    public bool startOn = true;

    private void Start()
    {
        if(!startOn)
        {
            Toggle();
        }
    }
    public virtual bool Switched
    {
        get
        {
            return _switched;
        }
        set
        {
            _switched = value;
        }
    }
    public virtual void Toggle()
    {
        Switched = !Switched;
    }
}
