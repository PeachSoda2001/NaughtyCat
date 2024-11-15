using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriiggerChangeScene : MonoBehaviour
{
    bool action;
    public string name;
    public GameObject UI;
    public AudioSource audio;
    //public static bool isTriggered = false; // ��̬���������ڱ���Ƿ��Ѵ���

    // Start is called before the first frame update
    void Start()
    {
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //TriggerManager manager = FindObjectOfType<TriggerManager>();
                //if (manager != null)
                //{
                //    manager.triggerCount++;
                //}
                //isTriggered = true;

                audio.Play();
                StartCoroutine(LoadSceneAfterDelay());
            }
        }
    }

    IEnumerator LoadSceneAfterDelay()
    {
        // �ȴ���Ч�������
        yield return new WaitForSeconds(1.5f);
        // �л�����
        SceneManager.LoadScene(name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        action = true;
        UI.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        action = false;
        UI.SetActive(false);
    }
}
