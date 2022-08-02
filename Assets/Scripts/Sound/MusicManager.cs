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

    // Awake is called before any Start functions
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
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

    public static MusicManager GetMusicManager()
    {
        return instance;
    }

    public void SetMusicParam(string paramName, float newValue)
    {
        if (paramName == "MasterVol" || paramName == "MusicVol" || paramName == "SFXVol")
        {
            // Set global FMOD parameter
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(paramName, newValue);
            MusicVol = newValue;
        }
        else
        {
            // Set emitter instance parameter
            emitter.SetParameter(paramName, newValue);    
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
