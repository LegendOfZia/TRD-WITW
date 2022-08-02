using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    FMODUnity.StudioEventEmitter emitter;

    public static AudioManager GetAudioManager()
    {
        return instance;
    }

    public static float MasterVol
    {
        get
        {
            return GetAudioVolume("MasterVol");
        }
        set
        {
            SetAudioVolume("MasterVol", value);
        }
    }

    public static float MusicVol
    {
        get
        {
            return GetAudioVolume("MusicVol");
        }
        set
        {
            SetAudioVolume("MusicVol", value);
        }
    }

    public static float SFXVol
    {
        get
        {
            return GetAudioVolume("SFXVol");
        }
        set
        {
            SetAudioVolume("SFXVol", value);
        }
    }

    private static float GetAudioVolume(string volumeParam)
    {
        if (volumeParam == "MasterVol" || volumeParam == "MusicVol" || volumeParam == "SFXVol")
        {
            // Get global FMOD parameter
            float temp = 1.0f;
            FMODUnity.RuntimeManager.StudioSystem.getParameterByName(volumeParam, out temp);
            return temp;
        }
        else
        {
            throw new ArgumentException(nameof(volumeParam), volumeParam + " is not a valid volume parameter.");
        }
    }

    private static void SetAudioVolume(string volumeParam, float newValue)
    {
        if (volumeParam == "MasterVol" || volumeParam == "MusicVol" || volumeParam == "SFXVol")
        {
            if (newValue < 0.0f || newValue > 1.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(newValue), "The valid range is between 0.0 and 1.0.");
            }
            else
            {
                // Set global FMOD parameter
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(volumeParam, newValue);
            }
        }
        else
        {
            throw new ArgumentException(nameof(volumeParam), volumeParam + " is not a valid volume parameter.");
        }
    }

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
            StartMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Make Danger into FMOD global parameter?
        SetMusicParam("Danger", 50 * (float)Math.Sin(2 * Math.PI * Time.timeSinceLevelLoad / 120 - 0.5) + 50);
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (scene.name == "CompletionScreen") {
            StopMusic();
        }
        else if (scene.name =="MainMenu") {
            StartMusic();
        }
    }

    private void SetMusicParam(string paramName, float newValue)
    {
        // Set emitter instance parameter
        // TODO: Split into separate MusicPlayer?
        emitter.SetParameter(paramName, newValue);
    }

    public void StartMusic()
    {
        emitter.Play();
    }

    public void StopMusic()
    {
        emitter.Stop();
    }

    public void MuteMusicLoop()
    {
        SetMusicParam("LoopActive", 0);
    }

    public void UnmuteMusicLoop()
    {
        SetMusicParam("LoopActive", 1);
    }
}
