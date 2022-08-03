using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundThreshold : MonoBehaviour
{

    [SerializeField]
    [Range(0,100)]
    public int DangerLevel = 0;

    AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.GetAudioManager();
    }

    public void ChangeAreaDanger()
    {
        audioManager.AreaDanger = DangerLevel;
        Debug.Log("Area danger change: " + DangerLevel);
    }
}
