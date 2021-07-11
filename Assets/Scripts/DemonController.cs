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
    private Animator anim;

    public bool isSummoned = false;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameManager.instance.GetPlayer();
    }

    void Update()
    {
        if (target) {
            if (isSummoned) {
                ChaseTarget();
            }

            FaceTarget();
        } else {
            moveDir = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        body.velocity = moveDir * MOVE_SPEED;
    }

    void ChaseTarget()
    {
        moveDir = target.position - transform.position;
        moveDir.Normalize();
    }

    void FaceTarget()
    {
        float dot = Vector2.Dot(transform.right, moveDir);
        if (dot > 0) {
            sprite.flipX = false;
        } else if (dot < 0) {
            sprite.flipX = true;
        }
    }
}
