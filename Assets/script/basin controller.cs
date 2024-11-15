using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basincontroller : MonoBehaviour
{
    public Animator animation;
    public GameObject icon;
    bool action;
    bool end;
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
                    animation.SetBool("pouring stop", false);
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
                    animation.SetBool("pouring stop", true);
                    animation.SetTrigger("is pouring");
                    end = true;
                }
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            action = true;
            icon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            action = false;
            icon.SetActive(false);
        }
    }
}
