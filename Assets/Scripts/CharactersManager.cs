
using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public void Start()
    {
        foreach (var character in Characters)
        {
            CharactersDictionary.Add(character.name, character);
            print(character.name);
        }
    }
}