using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVcontrol : MonoBehaviour
{
    public Animator animation;
    bool action;
    bool end = false;
    public GameObject icon;

    public AudioSource audio;
    public bool isTriggered = false; // 静态变量，用于标记是否已触发


    // Start is called before the first frame update
    void Start()
    {
        
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
                    audio.Stop();
                    animation.SetBool("TV on", false);
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

                    audio.Play();
                    animation.SetBool("TV on", true);
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
