using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsActive : MonoBehaviour
{
    public GameObject GoodObject;
    public GameObject BadObject;
    public GameObject icon;
    public GameObject trigger;
    bool action;

    public AudioSource audio;
    public bool isTriggered = false; // 静态变量，用于标记是否已触发

    // Start is called before the first frame update
    void Start()
    {
        GoodObject.SetActive(true);
        BadObject.SetActive(false);
        icon.SetActive(false);
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            if (!isTriggered && Input.GetKeyDown(KeyCode.E))
            {
                TriggerManager manager = FindObjectOfType<TriggerManager>();
                if (manager != null)
                {
                    manager.UpdateTriggerCount();
                }
                isTriggered = true;
                trigger.SetActive(false);
                GoodObject.SetActive(false);
                BadObject.SetActive(true);
                audio.Play();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            icon.SetActive(true);
            action = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            icon.SetActive(false);
            action = false;
        }
    }
}
