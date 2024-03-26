using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ISpeakingPerson
{
    
    public TMP_Text Text { get; set; }
    public bool IsSpeaking { get; set; }
    
    public virtual void Speak(string message)
    {
        IsSpeaking = true;
        Text.text = "";
        foreach (char c in message)
        {
            Text.text += c;
            System.Threading.Thread.Sleep(10);
        }
        IsSpeaking = false;
    }
    
    public virtual void ImmediateSpeak(string message)
    {
        Text.text = message;
    }
}