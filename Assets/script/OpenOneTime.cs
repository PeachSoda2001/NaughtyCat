using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOneTime : MonoBehaviour
{
    public Animator animation;
    public string animationName;
    public GameObject icon;
    bool action;
    public GameObject trigger;
    public bool isTriggered = false; // 静态变量，用于标记是否已触发

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        action = false;
        icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTriggered && action && Input.GetKeyDown(KeyCode.E))
        {
            audio.Play();
            TriggerManager manager = FindObjectOfType<TriggerManager>();
            if (manager != null)
            {
                manager.UpdateTriggerCount();
            }
            isTriggered = true;

            animation.SetBool(animationName, true);
            Destroy(trigger);
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
