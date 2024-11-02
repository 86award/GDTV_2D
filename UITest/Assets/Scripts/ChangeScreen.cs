using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField] GameObject currentScreen;
    [SerializeField] GameObject targetScreen;

    public void ChangeToTargetScreen()
    {
        currentScreen.SetActive(false);
        targetScreen.SetActive(true);
    }
}
