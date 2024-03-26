
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CharactersManager: MonoBehaviour
{
    public static List<Transform> GetFirstOrderChildren(Transform parent)
    {
        List<Transform> firstOrderChildren = new List<Transform>();
        for (int i = 0; i < parent.childCount; i++)
        {
            firstOrderChildren.Add(parent.GetChild(i));
        }
        return firstOrderChildren;
    }

    public static Dictionary<string, Transform> CharactersDictionary = new Dictionary<string, Transform>();
    
    public static List<Transform> Characters;

    public void Awake()
    {
        Characters = GetFirstOrderChildren(this.transform);
        foreach (var character in Characters)
        {
            CharactersDictionary.Add(character.name, character);
        }
    }
    
    public static Transform GetCharacter(string characterName)
    {
        print(characterName);
        return CharactersDictionary[characterName];
    }
}