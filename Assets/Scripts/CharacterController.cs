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
    Animator animator;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
         motionVector = new Vector2(
             Input.GetAxisRaw("Horizontal"),
             Input.GetAxisRaw("Vertical")
             );
         animator.SetFloat("horizontal", motionVector.x);
         animator.SetFloat("vertical", motionVector.y);
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
