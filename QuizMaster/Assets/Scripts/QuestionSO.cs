using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField] private string[] answers = new string[] { "", "", "", "", };

    [TextArea(2, 6)]
    [SerializeField] private string question = "Enter a question here";
    public string Question
    {
        get { return question; }
    }
    
    [SerializeField] private int correctAnswerIndex;
    public int CorrectAnswerIndex
    {
        get { return correctAnswerIndex; }
    }
    
    public string GetAnswer(int answerIndex)
    {
        return answers[answerIndex];
    }
}