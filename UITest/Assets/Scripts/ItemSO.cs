using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Create New ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private itemSOClassification itemType;

    private enum itemSOClassification
    {
        Spell = 0,
        Armour = 1,
        Weapon = 2,
    }

    public Sprite GetItemImage()
    {
        return itemImage;
    }
}
