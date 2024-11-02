using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendSlotToBeAssigned : MonoBehaviour
{
    [SerializeField] int selectedInventorySlot;
    [SerializeField] CharacterUpdate charUpate; // This feels like such a brute force way of doing it though!

    public void SendSlot()
    {
        charUpate.inventorySlotToBeAssigned = selectedInventorySlot;
        //GetComponentInParent<CharacterUpdate>().inventorySlotToBeAssigned = selectedInventorySlot;
    }

    // assing the field a literal 0, 1, 2
    // pass the literal to a method that assign new item to inventory[literal]
    //public void OnSlotSelect()
    //{
    //    GetComponentInParent<CharacterUpdate>().inventorySlotToBeAssigned = selectedInventorySlot;
    //}


    // NOW I REMEMBER THAT GETCOMPONENT RETURNS THE FIRST INSTANCE THAT IT FINDS
}
