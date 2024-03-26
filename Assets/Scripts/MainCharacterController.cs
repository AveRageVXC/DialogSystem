using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


[RequireComponent(typeof(Rigidbody2D))]
public class MainCharacterController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed = 4f;
    public float interactionRadius = 3.0f;
    [FormerlySerializedAs("lastInteractablePerson")] public InteractableNPC lastInteractableNpc;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    Animator animato2r;
    public bool moving;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
         CheckForClosestPerson();
         
    }

    private void CheckForClosestPerson()
    {
        var closestPerson = Physics2D.OverlapCircleAll(transform.position, interactionRadius)
            .Select(collider => collider.GetComponent<InteractableNPC>())
            .Where(person => person != null)
            .OrderBy(person => Vector2.Distance(transform.position, person.transform.position))
            .FirstOrDefault();
        
        if (lastInteractableNpc != null && lastInteractableNpc != closestPerson)
        {
            lastInteractableNpc.HideInteractionHind();
        }
        lastInteractableNpc = closestPerson;
        if (closestPerson != null)
        {
            closestPerson.ShowInteractionHind();
            // print("Closest person is " + closestPerson.name);
        }
        if (Input.GetKeyDown("e") && closestPerson != null)
        {
            InteractWithClosestPerson(closestPerson);
        }
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = motionVector.normalized * speed;
    }
    
    private void InteractWithClosestPerson(InteractableNPC npc)
    {
        if (npc != null)
        {
            npc.StartDialogue();
        }
    }
}
