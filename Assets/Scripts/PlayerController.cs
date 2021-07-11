using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float MIN_IDLE_TIME = 2.5f;
    const float MAX_IDLE_TIME = 5f;
    const float BLINK_TIME = 0.1f;

    const float MOVE_SPEED = 5f;

    float idleTimer;
    float maxIdleTimer;

    Vector2 moveDir = Vector2.zero;

    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        maxIdleTimer = Random.Range(MIN_IDLE_TIME, MAX_IDLE_TIME);
        idleTimer = maxIdleTimer;
    }

    void Update()
    {
        HandleMoveInput();
        TickBlinkTimer();
    }

    void FixedUpdate()
    {
        body.velocity = moveDir * MOVE_SPEED;
    }

    void HandleMoveInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        if (!anim.GetBool("isMoving") && moveDir != Vector2.zero) {
            anim.SetBool("isMoving", true);
        } else if (anim.GetBool("isMoving") && moveDir == Vector2.zero) {
            anim.SetBool("isMoving", false);
        }

        if (moveDir.x > 0) {
            sprite.flipX = false;
        } else if (moveDir.x < 0) {
            sprite.flipX = true;
        }
    }

    void TickBlinkTimer()
    {
        if (anim.GetBool("isMoving")) {
            return;
        }

        idleTimer -= Time.deltaTime;

        if (idleTimer <= 0) {
            if (anim.GetBool("isBlinking")) {
                anim.SetBool("isBlinking", false);
                maxIdleTimer = Random.Range(MIN_IDLE_TIME, MAX_IDLE_TIME);
            } else {
                anim.SetBool("isBlinking", true);
                maxIdleTimer = BLINK_TIME;
            }

            idleTimer = maxIdleTimer;
        } 
    }
}
