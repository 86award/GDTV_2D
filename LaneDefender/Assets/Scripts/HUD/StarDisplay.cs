using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int starCount = 100;
    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        textMeshPro.text = starCount.ToString();
    }

    public void AddStars(int value)
    {
        starCount += value;
        UpdateDisplayText();
    }

    public bool HaveEnoughStars(int value)
    {
        return starCount >= value;
    }

    public void SubtractStars(int value)
    {
        if (starCount >= value)
        {
            starCount -= value;
        }
        UpdateDisplayText();
    }
}
