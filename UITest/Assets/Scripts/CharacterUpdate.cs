using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CharacterUpdate : MonoBehaviour
{
    [SerializeField] Image portraitField;
    [SerializeField] TextMeshProUGUI nameField;
    [SerializeField] TextMeshProUGUI storyField;
    [SerializeField] Button[] inventoryArrayButtons = new Button[3];
    [SerializeField] TextMeshProUGUI abilityPointsField;

    private int characterIndex = 0;
    public int CharacterIndex
    {
        get
        {
            return characterIndex;
        }
        set
        {
            characterIndex = value;
        }
    }

    [Header("Attributes")]
    [SerializeField] GameObject[] fightAttributeLevel = new GameObject[3];
    [SerializeField] GameObject[] magicAttributeLevel = new GameObject[3];
    [SerializeField] GameObject[] healthAttributeLevel = new GameObject[3];
    //int fightLevel;
    //int magicLevel;
    //int healthLevel;
    int[] currentCharacterAttributes;

    public int inventorySlotToBeAssigned;

    private void Awake()
    {
        ChangeDisplayedCharacter(characterIndex);
    }
    public void ChangeDisplayedCharacter(int index)
    {
        UpdateCharacterPortrait(index);
        UpdateCharacterName(index);
        UpdateCharacterStory(index);
        UpdateCharacterInventory(index);
        UpdateCharacterAbilityPoints(index);
        UpdateCharacterAttributeLevels(index);
        CharacterIndex = index;
    }

    // Methods for updating the screen assets e.g. portrait, name, story, inventory, attribute points
    private void UpdateCharacterPortrait(int index)
    {
        portraitField.sprite = GetComponentInParent<CharacterRoster>().characterRoster[index].GetCharacterPortrait();
    }
    private void UpdateCharacterName(int index)
    {
        nameField.text = GetComponentInParent<CharacterRoster>().characterRoster[index].GetCharacterName();
    }
    private void UpdateCharacterStory(int index)
    {
        storyField.text = GetComponentInParent<CharacterRoster>().characterRoster[index].GetCharacterStory();
    }
    private void UpdateCharacterInventory(int index)
    {
        for (int i = 0; i < inventoryArrayButtons.Length; i++)
        {
            inventoryArrayButtons[i].image.sprite = GetComponentInParent<CharacterRoster>().characterRoster[index].inventory[i].GetItemImage();
        }
    }
    private void UpdateCharacterAbilityPoints(int index)
    {
        abilityPointsField.text = GetComponentInParent<CharacterRoster>().characterRoster[index].AbilityPoints.ToString();
    }


    // AttributeIcons
    public void UpdateCharacterAttributeLevels(int index)
    {
        // This is going to be called when changing selected character
        currentCharacterAttributes = new[]
        {
            GetComponentInParent<CharacterRoster>().characterRoster[index].FightAttribute,
            GetComponentInParent<CharacterRoster>().characterRoster[index].MagicAttribute,
            GetComponentInParent<CharacterRoster>().characterRoster[index].HealthAttribute,
        };

        foreach (GameObject item in fightAttributeLevel)
        {
            item.GetComponent<Image>().enabled = false;
        }
        foreach (GameObject item in magicAttributeLevel)
        {
            item.GetComponent<Image>().enabled = false;
        }
        foreach (GameObject item in healthAttributeLevel)
        {
            item.GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < currentCharacterAttributes[0]; i++)
        {
            fightAttributeLevel[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < currentCharacterAttributes[1]; i++)
        {
            magicAttributeLevel[i].GetComponent<Image>().enabled = true;
        }
        for (int i = 0; i < currentCharacterAttributes[2]; i++)
        {
            healthAttributeLevel[i].GetComponent<Image>().enabled = true;
        }
    }
    public void IncreaseFightAttributeIcon()
    {
        for (int i = 0; i <= currentCharacterAttributes[0]; i++)
        {
            fightAttributeLevel[i].GetComponent<Image>().enabled = true;
        }
    }
    public void DecreaseFightAttributeIcon()
    {
        fightAttributeLevel[currentCharacterAttributes[0] - 1].GetComponent<Image>().enabled = false;
    }

    // Magic
    public void IncreaseMagicAttributeIcon()
    {
        for (int i = 0; i <= currentCharacterAttributes[1]; i++)
        {
            magicAttributeLevel[i].GetComponent<Image>().enabled = true;
        }
    }
    public void DecreaseMagicAttributeIcon()
    {
        magicAttributeLevel[currentCharacterAttributes[1] - 1].GetComponent<Image>().enabled = false;
    }

    //Health
    public void IncreaseHealthAttributeIcon()
    {
        for (int i = 0; i <= currentCharacterAttributes[2]; i++)
        {
            healthAttributeLevel[i].GetComponent<Image>().enabled = true;
        }
    }
    public void DecreaseHealthAttributeIcon()
    {
        healthAttributeLevel[currentCharacterAttributes[2] - 1].GetComponent<Image>().enabled = false;
    }


    public void ReplaceCurrentCharInventory(ItemSO newItem)
    {
        //int index = GetComponentInChildren<SendSlotToBeAssigned>().SendSlot();
        int index = inventorySlotToBeAssigned;
        GetComponentInParent<CharacterRoster>().characterRoster[characterIndex].inventory[index] = newItem;
    }
}