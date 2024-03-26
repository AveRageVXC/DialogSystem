using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] List<DialoguePhrase> dialoguePhrases;
    
    public int currentPhrase = 0;
    IEnumerator dialogueCoroutine;

    public IEnumerator StartDialogue(MonoBehaviour runner)
    { 
        currentPhrase = 0;
        var speakingPersons = new HashSet<ISpeakingPerson>();
        foreach (var dialoguePhrase in dialoguePhrases)
        {
            var _personTransform = CharactersManager.GetCharacter(dialoguePhrase.person);
            var speakingPerson = _personTransform.GetComponent<ISpeakingPerson>();
            speakingPersons.Add(speakingPerson);
        }
        foreach (var speakingPerson in speakingPersons)
        {
            speakingPerson.IsInDialogue = true;
        }
        while (currentPhrase < dialoguePhrases.Count)
        {
            var _personTransform = CharactersManager.GetCharacter(dialoguePhrases[currentPhrase].person);
            yield return runner.StartCoroutine(_personTransform.GetComponent<ISpeakingPerson>().Speak(dialoguePhrases[currentPhrase].phrase));
            currentPhrase++;
            yield return null;
        }
        foreach (var speakingPerson in speakingPersons)
        {
            speakingPerson.IsInDialogue = false;
        }
    }
}