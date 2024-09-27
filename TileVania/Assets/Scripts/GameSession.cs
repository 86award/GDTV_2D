using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.InstanceID).Length;
        if (numGameSessions > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
        UpdateLivesText();
        AddToPoints();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1) TakeLife();
        else ResetGameSession();
    }

    private void TakeLife()
    {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        livesText.text = playerLives.ToString();
    }

    public void AddToPoints(int value = 0)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    private void ResetGameSession()
    {
        FindAnyObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
