using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableNPC: MonoBehaviour, ISpeakingPerson
{
    [SerializeField] public List<Dialogue> dialogues;
    [SerializeField] public int currentDialogue = 0;
    [SerializeField] public TMP_Text Text { get; set; }
    public bool IsInDialogue { get; set; }


    public void Awake()
    {
        Text = GetComponentInChildren<TMP_Text>();
    }

    public IEnumerator StartDialogue()
    {
        
        yield return StartCoroutine(dialogues[currentDialogue].StartDialogue(this));
        currentDialogue++;
    }

    public void ShowInteractionHind()
    {
        if (IsInDialogue is false)
        {
            Text.enabled = true;
            (this as ISpeakingPerson).ImmediateSpeak("Press E to interact");
        }
        
    }
    
    public void HideInteractionHind()
    {
        if (IsInDialogue is false)
        {
            Text.text = "";
        }
    }
}