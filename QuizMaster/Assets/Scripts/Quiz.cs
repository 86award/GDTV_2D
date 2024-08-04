using NUnit.Framework;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO question;
    [SerializeField] private GameObject[] answerButton;
    void Start()
    {
        questionText.text = question.Question;
        for (int i = 0; i < answerButton.Length; i++)
        {
            answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
        }
    }
}
