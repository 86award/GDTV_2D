using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] private string question = "Enter a question here";
    [SerializeField] private int correctAnswerIndex;
    public string Question
    {
        get { return question; }
    }
    public int CorrectAnswerIndex
    {
        get { return correctAnswerIndex; }
    }
    public string GetAnswer(int answerIndex)
    {
        return answers[answerIndex];
    }
    [SerializeField] private string[] answers = new string[]
    {
        "",
        "",
        "",
        "",
    };
}
