using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float timeToAnswer = 10f;
    [SerializeField] private float timeToCompleteQuestion = 5f;
    public float timerValue;
    public bool isAnsweringQuestions = true; // start the game with time to answer a Q
    public bool loadNextQuestion;
    
    void Update()
    {
        UpdateTimer();
        // what state is the game in
        // how long to answer Q
        // has time run out
        // if timer has run out, change state
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestions)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestions = false;
                timerValue = timeToCompleteQuestion;
            }
            else timerImage.fillAmount = timerValue / timeToAnswer;
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestions = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
            else timerImage.fillAmount = timerValue / timeToCompleteQuestion;
        }
    }
}
