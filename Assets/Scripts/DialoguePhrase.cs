using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class DialoguePhrase
{
    [SerializeField] public string person;
    [SerializeField] public string phrase;
    private Transform _personTransform;

    public void Speak(MonoBehaviour runner)
    {
        _personTransform = CharactersManager.GetCharacter(person);
        runner.StartCoroutine(_personTransform.GetComponent<ISpeakingPerson>().Speak(phrase));
    }
}