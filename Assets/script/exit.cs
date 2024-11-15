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
        // �ڿ�ʼʱ���ҳ��������е�AudioSource������������Ǵ洢��������
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
                source.UnPause(); // ����ʹ�� source.Play(); ����ͷ��ʼ����
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
