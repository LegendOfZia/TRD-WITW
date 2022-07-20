using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVictory : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("MusicVol", MusicManager.GetMusicVol());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
