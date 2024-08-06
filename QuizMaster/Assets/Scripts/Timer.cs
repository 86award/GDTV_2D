using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float timeToAnswer = 10f;
    [SerializeField] private float timeToReviewAnswer = 5f;
    public float timerValue;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;
    
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (timerValue > 0) timerImage.fillAmount = timerValue / timeToAnswer;
            else 
            {
                isAnsweringQuestion = false;
                timerValue = timeToReviewAnswer;
            }
        }
        else
        {
            if (timerValue > 0) timerImage.fillAmount = timerValue / timeToReviewAnswer;
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }
    }
}
