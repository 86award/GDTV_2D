using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Create New CharacterSO")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private Sprite _characterPortrait;

    [TextArea(2, 7)]
    [SerializeField] private string characterBackgound;

    [Range(0, 5)]
    [SerializeField] private int _abilityPointsToSpend = 5;

    [Header("Attributes")]
    [SerializeField] private int fightAttribute = 0;
    [SerializeField] private int magicAttribute = 0;
    [SerializeField] private int healthAttribute = 0;
    // Could/should these be stored in an array or list?

    public int AbilityPoints { get { return _abilityPointsToSpend; } set { _abilityPointsToSpend = value; } }
    public int FightAttribute { get { return fightAttribute; } set { fightAttribute = value; } }
    public int MagicAttribute { get { return magicAttribute; } set { magicAttribute = value; } }
    public int HealthAttribute { get { return healthAttribute; } set { healthAttribute = value; } }

    public string GetCharacterName()
    {
        return _characterName;
    }
    public Sprite GetCharacterPortrait()
    {
        return _characterPortrait;
    }
    public string GetCharacterStory()
    {
        return characterBackgound;
    }

    public List<ItemSO> inventory = new List<ItemSO>();

    // Redundant code
    //public int GetAbilityPointsToSpend()
    //{
    //    return _abilityPointsToSpend;
    //}
}
