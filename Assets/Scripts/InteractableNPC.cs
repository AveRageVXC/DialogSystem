using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableNPC: MonoBehaviour, ISpeakingPerson
{
    [SerializeField] public List<Dialogue> dialogues;
    [SerializeField] public int currentDialogue = 0;
    [SerializeField] public TMP_Text Text { get; set; }
    public bool IsSpeaking { get; set; }


    public void Awake()
    {
        Text = GetComponentInChildren<TMP_Text>();
    }

    public void StartDialogue()
    {
        StartCoroutine(dialogues[currentDialogue].StartDialogue());
    }

    public void ShowInteractionHind()
    {
        if (!IsSpeaking)
        {
            Text.enabled = true;
            (this as ISpeakingPerson).ImmediateSpeak("Press E to interact");
        }
    }
    
    public void HideInteractionHind()
    {
        Text.enabled = false;
    }
}