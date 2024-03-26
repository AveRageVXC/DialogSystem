using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableNPC: MonoBehaviour
{
    [SerializeField] public Dialogue[] dialogues;
    [SerializeField] public TMP_Text hindText;
    
    public void Awake()
    {
        hindText = GetComponentInChildren<TMP_Text>();
    }

    public void StartDialogue()
    {
        Console.WriteLine("Starting dialogue with person");
    }

    public void ShowInteractionHind()
    {
        hindText.enabled = true;
        hindText.text = "Press E to interact";
    }
    
    public void HideInteractionHind()
    {
        hindText.text = "";
        hindText.enabled = false;
    }
    
    
}