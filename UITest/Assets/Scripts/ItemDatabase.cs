using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField] List<ItemSO> itemSODatabase = new List<ItemSO>();
    [SerializeField] List<Button> itemSOInventoryImages = new List<Button>();

    private void Update()
    {
        // Need to figure out how I would sort the item database based on item class.

        for (int i = 0; i < itemSOInventoryImages.Count; i++)
        {
            itemSOInventoryImages[i].image.sprite = itemSODatabase[i].GetItemImage();
        }
    }
}
