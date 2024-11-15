using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanMove : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private bool isMoving = false;
    public string nameScene;

    void Update()
    {
        if (isMoving && Vector3.Distance(transform.position, player.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    public void StartAttack()
    {
        isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerPlayerHitEffect();
        }
    }

    private void TriggerPlayerHitEffect()
    {
        Debug.Log("玩家被攻击对象触碰！");
        SceneManager.LoadScene(nameScene);
        isMoving = false;
    }
}
