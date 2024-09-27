using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings) nextScene = 0;
            if (other.GetComponent<PlayerMovement>())
            {
                StartCoroutine(TriggerExit(nextScene));
            } 
        }
    }

    IEnumerator TriggerExit(int nextScene)
    {
        yield return new WaitForSecondsRealtime(1f);
        FindAnyObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextScene);
    }
}
