using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] List<DialoguePhrase> dialoguePhrases;
    public int currentPhrase = 0;


    public IEnumerator StartDialogue()
    {
        if (currentPhrase < dialoguePhrases.Count)
        {
            dialoguePhrases[currentPhrase].Speak();
            currentPhrase++;
            
        }
        return null;
    }
}
/*public void NextPhrase()
{
    if (currentPhrase < dialogue.Count)
    {

        dialogue[currentPhrase].Item2.Speak(dialogue[currentPhrase].Item1);
        currentPhrase++;
    }
}
}*/
