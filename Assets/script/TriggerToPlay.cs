using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToPlay : MonoBehaviour
{
    public Animator animation;
    bool action;
    bool end;
    public GameObject icon;
    public AudioSource audio;
    public AudioSource stopAudio;
    public bool isTriggered = false; // 静态变量，用于标记是否已触发

    // Start is called before the first frame update
    void Start()
    {
        action = false;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (end)
                {
                    stopAudio.Play();
                    animation.SetBool("water in", false);
                    animation.SetTrigger("water out");
                    end = false;
                }
                else
                {
                    TriggerManager manager = FindObjectOfType<TriggerManager>();
                    if (!isTriggered && manager != null)
                    {
                        manager.UpdateTriggerCount();
                    }
                    isTriggered = true;

                    animation.SetBool("water in", true);
                    audio.Play();
                    end = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            action = true;
            icon.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            action = false;
            icon.SetActive(false);
        }
    }
}
