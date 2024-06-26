using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


[RequireComponent(typeof(Rigidbody2D))]
public class MainCharacterController : MonoBehaviour, ISpeakingPerson
{
    public TMP_Text Text { get; set; }
    public bool IsInDialogue { get; set; }
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
        Text = GetComponentInChildren<TMP_Text>();
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
         
         if (IsInDialogue is false)
         {
             CheckForClosestPerson();             
         }
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
        if (closestPerson != null && closestPerson.currentDialogue < closestPerson.dialogues.Count)
        {
            closestPerson.ShowInteractionHind();
            if (Input.GetKeyDown("e"))
            {
                InteractWithClosestPerson(closestPerson);
            }
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
            StartCoroutine(npc.StartDialogue());
        }
    }
}
