using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public GameObject PauseUI;
    bool action = false;

    public AudioSource[] audioSources;

    void Start()
    {
        // 在开始时查找场景中所有的AudioSource组件，并将它们存储在数组中
        audioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (action == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PauseAllAudio();
                PauseUI.SetActive(true);
                Time.timeScale = 0;
                action = true;
            }
            else
            {
                Continue();
            }
        }

    }
    public void PauseAllAudio()
    {
        foreach (var source in audioSources)
        {
            if (source.isPlaying)
            {
                source.Pause();
            }
        }
    }
    public void PlayAllAudio()
    {
        foreach (var source in audioSources)
        {
            if (!source.isPlaying)
            {
                source.UnPause(); // 或者使用 source.Play(); 来从头开始播放
            }
        }
    }
    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayAllAudio();
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        action = false;
    }
}
