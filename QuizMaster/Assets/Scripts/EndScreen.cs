using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        scoreText.text = "Congratulation!\n You scored " +
                        scoreKeeper.CalculateScore() + "%";       
    }
}
