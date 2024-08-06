using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int questionsSeen = 0;
    public int QuestionsSeen { get { return questionsSeen; } set { questionsSeen += value; } }

    int correctAnswers = 0;
    public int CorrectAnswers { get { return correctAnswers;} set { correctAnswers += value; } }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)QuestionsSeen * 100);
    }
}
