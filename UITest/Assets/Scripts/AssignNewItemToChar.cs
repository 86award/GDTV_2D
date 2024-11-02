using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignNewItemToChar : MonoBehaviour
{
    [SerializeField] ItemSO newItem;
    // assign the current characters sent inv slot to the newly selected item
    public void OnItemSelection()
    {
        FindObjectOfType<CharacterUpdate>().ReplaceCurrentCharInventory(newItem);

        FindObjectOfType<CharacterUpdate>().ChangeDisplayedCharacter(FindObjectOfType<CharacterUpdate>().CharacterIndex);
    }
}
