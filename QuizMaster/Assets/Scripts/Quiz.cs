using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionText;
    private QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questionList;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButton;
    private bool hasAnsweredEarly;
    
    [Header("Buttons")]
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Timer")]
    Timer timer;

    void Start()
    {
        timer  = FindAnyObjectByType<Timer>();
        questionText.text = currentQuestion.Question;
        for (int i = 0; i < answerButton.Length; i++)
        {
            answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.GetAnswer(i);
        }
    }

    void Update()
    {
        if(timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestions)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void GetNextQuestion()
    {
        if (questionList.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
        }
    }

    private void GetRandomQuestion()
    {
        int random = UnityEngine.Random.Range(0, questionList.Count);
        currentQuestion = questionList[random];
        try
        {
            questionList.Remove(currentQuestion);
        }
        catch (System.Exception)
        {
            Debug.Log("Question {questionList.Remove(currentQuestion)} not found");
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image buttonImage = answerButton[i].GetComponent<Image>();
            buttonImage.sprite = defaultSprite;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == currentQuestion.CorrectAnswerIndex)
        {
            questionText.text = "Correct";
            buttonImage = answerButton[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = $"That was incorrect. The answer was:\n{currentQuestion.GetAnswer(currentQuestion.CorrectAnswerIndex)}";
            buttonImage = answerButton[currentQuestion.CorrectAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button buttonState = answerButton[i].GetComponent<Button>();
            buttonState.interactable = state;
        }
    }
}
