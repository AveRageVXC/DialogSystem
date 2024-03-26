using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface ISpeakingPerson
{
    
    public TMP_Text Text { get; set; }
    public bool IsInDialogue { get; set; }
    
    public IEnumerator Speak(string message)
    {
        Text.text = "";
        Debug.Log(message);
        foreach (char c in message)
        {
            Text.text += c;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        Text.text = "";
    }
    
    public void ImmediateSpeak(string message)
    {
        Text.text = message;
    }
}