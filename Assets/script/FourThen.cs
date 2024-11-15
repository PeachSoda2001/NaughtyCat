using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourThen : MonoBehaviour
{
    private Collider2D coll;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    //private Animator animator;

    public float moveSpeed = 5f;

    public bool canMove = true;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        canMove = true;
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }

        if (canMove)
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            float dirY = Input.GetAxisRaw("Vertical");
            Vector2 moveDir = new Vector2(dirX, dirY);

            if (moveDir.magnitude > 0)
            {
                // ????????????0??360??
                float angle = Mathf.Atan2(dirY, dirX) * Mathf.Rad2Deg;
                if (angle < 0) angle += 360;

                // ????????????
                sp.flipX = angle > 90 && angle < 270;

                // ????????????Animator????????
                if (angle == 0 || angle == 180)
                {
                    //animator.SetInteger("Direction", 1); // ??
                }
                if (angle == 90)
                {
                    //animator.SetInteger("Direction", 2); // ??
                }
                if (angle == 270)
                {
                    //animator.SetInteger("Direction", 3); // ??
                }
            }

            // ????Animator????????
            //animator.SetFloat("Speed", moveDir.magnitude);

            // ????????
            rb.velocity = moveDir * moveSpeed;
        }
    }

}
