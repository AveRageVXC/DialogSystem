using UnityEngine;

[System.Serializable]
public class DialoguePhrase
{
    public string person;
    public string phrase;
    private Transform _personTransform;
    public void Speak()
    {
        _personTransform = CharactersManager.GetCharacter(person);
        _personTransform.GetComponent<ISpeakingPerson>().Speak(phrase);
    }
}