using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] Base baseArea;
    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        baseArea = FindAnyObjectByType<Base>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        textMeshPro.text = $"Lives: {baseArea.Lives.ToString()}";
    }

    public void AddLives(int value)
    {
        baseArea.Lives += value;
        UpdateDisplayText();
    }

    /*
    public bool HaveEnoughStars(int value)
    {
        return lifeCount >= value;
    }
    */

    public void SubtractLives(int value)
    {
        if (baseArea.Lives >= value)
        {
            baseArea.Lives -= value;
        }
        UpdateDisplayText();

        if (baseArea.Lives <= 0)
        {
            FindAnyObjectByType<LevelController>().HandleLoseCondition();
        }
    }
}


