using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeCharacter : MonoBehaviour
{
    private int rosterSize;
    private int currentCharacterIndex;
    // Change step to Awake
    private void Awake()
    {
        rosterSize = GetComponentInParent<CharacterRoster>().characterRoster.Count;
        currentCharacterIndex = GetComponentInParent<CharacterUpdate>().CharacterIndex;
    }

    private void Update()
    {
        currentCharacterIndex = GetComponentInParent<CharacterUpdate>().CharacterIndex;
    }
    public void IncrementDisplayedCharacter()
    {
        if (currentCharacterIndex == (rosterSize - 1))
        {
            currentCharacterIndex = 0;
            GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
            return;
        }
        currentCharacterIndex++;
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }
    public void DecrementDisplayedCharacter()
    {
        if (currentCharacterIndex == 0)
        {
            currentCharacterIndex = (rosterSize - 1); // I was forgetting here that you needed to index at one less than count, though I remembered above!
            GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
            return;
        }
        currentCharacterIndex--;
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }

    // Fight
    public void IncrementFightAttribute()
    {
        if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].FightAttribute >= 3)
        {

        }
        else
        {
            if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints > 0)
            {
                GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].FightAttribute++;
                GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints--;
            }
        }
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }
    public void DecrementFightAttribute()
    {
        if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].FightAttribute == 0)
        {

        }
        else
        {
            GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].FightAttribute--;
            GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints++;
        }
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }

    // Magic
    public void IncrementMagicAttribute()
    {
        if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].MagicAttribute >= 3)
        {

        }
        else
        {
            if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints > 0)
            {
                GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].MagicAttribute++;
                GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints--;
            }
        }
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }
    public void DecrementMagicAttribute()
    {
        if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].MagicAttribute == 0)
        {

        }
        else
        {
            GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].MagicAttribute--;
            GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints++;
        }
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }

    // Health
    public void IncrementHealthAttribute()
    {
        if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].HealthAttribute >= 3)
        {

        }
        else
        {
            if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints > 0)
            {
                GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].HealthAttribute++;
                GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints--;
            }
        }
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }
    public void DecrementHealthAttribute()
    {
        if (GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].HealthAttribute == 0)
        {

        }
        else
        {
            GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].HealthAttribute--;
            GetComponentInParent<CharacterRoster>().characterRoster[currentCharacterIndex].AbilityPoints++;
        }
        GetComponentInParent<CharacterUpdate>().ChangeDisplayedCharacter(currentCharacterIndex);
    }
}
