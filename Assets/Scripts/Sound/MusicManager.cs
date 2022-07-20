using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance;
    static float MusicVol = 1.0f;
    FMODUnity.StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            emitter = GetComponent<FMODUnity.StudioEventEmitter>();
            SceneManager.sceneLoaded += OnSceneLoad;
            StartMusicLoop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicParam("Danger", 50 * (float)Math.Sin(2 * Math.PI * Time.timeSinceLevelLoad / 120 - 0.5) + 50);
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (scene.name == "CompletionScreen") {
            MuteMusicLoop();
        }
        else if (scene.name =="MainMenu") {
            UnmuteMusicLoop();
        }
    }

    public void SetMusicParam(string paramName, float newValue)
    {
        emitter.SetParameter(paramName, newValue);

        if (paramName == "MusicVol")
        {
            MusicVol = newValue;
        }
    }

    public void StartMusicLoop()
    {
        emitter.Play();
    }

    public void MuteMusicLoop()
    {
        SetMusicParam("LoopActive", 0);
    }

    public void UnmuteMusicLoop()
    {
        SetMusicParam("LoopActive", 1);
    }

    public static float GetMusicVol()
    {
        return MusicVol;
    }

}
