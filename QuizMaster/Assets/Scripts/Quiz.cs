using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Timer")]
    Timer timer;

    [Header("Questions")]
    private QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questionList;
    [SerializeField] private TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButton;
    private bool hasAnsweredEarly = true;
    
    [Header("Buttons")]
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI score;
    ScoreKeeper scoreKeeper;

    [SerializeField] Slider progressBar;
    public bool isComplete;

    void Awake()
    {
        timer = FindAnyObjectByType<Timer>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        progressBar = FindAnyObjectByType<Slider>();
        progressBar.maxValue = questionList.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        if(timer.loadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        // If player didn't answer in time and timer ran out, show answer and disable buttons
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuestion.Question;
        for (int i = 0; i < answerButton.Length; i++)
        {
             answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.GetAnswer(i);
        }
    }

    private void GetNextQuestion()
    {
        if (questionList.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            scoreKeeper.QuestionsSeen = 1; // Increment Qs seen
            progressBar.value++;
        }
    }

    private void GetRandomQuestion()
    {
        int random = UnityEngine.Random.Range(0, questionList.Count);
        currentQuestion = questionList[random];
        questionList.Remove(currentQuestion);
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
        score.text = $"Score: {scoreKeeper.CalculateScore()}%";
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == currentQuestion.CorrectAnswerIndex)
        {
            questionText.text = "Correct";
            buttonImage = answerButton[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.CorrectAnswers = 1; // Inc. right answer
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