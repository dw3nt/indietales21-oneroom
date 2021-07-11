using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    const float MOVE_SPEED = 2f;

	private Transform target;

    private Vector2 moveDir;

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        target = GameManager.instance.GetPlayer();
    }

    void Update()
    {
        moveDir = target.position - transform.position;
        moveDir.Normalize();

        float dot = Vector2.Dot(transform.right, moveDir);
        if (dot > 0) {
            sprite.flipX = false;
        } else if (dot < 0) {
            sprite.flipX = true;
        }
    }

    void FixedUpdate()
    {
        body.velocity = moveDir * MOVE_SPEED;
    }
}
