using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterRoster : MonoBehaviour
{
    [SerializeField] public List<CharacterSO> characterRoster = new List<CharacterSO>();

    public int RosterSize()
    {
        return characterRoster.Count;
    }
}
