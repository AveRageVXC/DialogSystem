using System;
using UnityEngine;

public class InteractablePerson: MonoBehaviour
{
    public DialogueContainer dialogue;

    public void StartDialogue()
    {
        Console.WriteLine("Starting dialogue with person");
    }
}