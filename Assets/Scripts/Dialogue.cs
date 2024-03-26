using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] DialoguePhrase[] dialoguePhrases;
    public int currentPhrase = 0;
    
    
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
