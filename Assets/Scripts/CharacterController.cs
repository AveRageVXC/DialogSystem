using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 4f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(
            horizontal,
            vertical
             ).normalized;
        
         animator.SetFloat("horizontal", horizontal);
         animator.SetFloat("vertical", horizontal);
         moving = horizontal != 0 || vertical != 0;
         if (horizontal != 0 || vertical != 0)
         {
             lastMotionVector = new Vector2(
                 horizontal,
                 vertical
                 ).normalized;
             animator.SetFloat("lastHorizontal", horizontal);
                animator.SetFloat("lastVertical", vertical);
         }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2D.velocity = motionVector.normalized * speed;
    }
}
