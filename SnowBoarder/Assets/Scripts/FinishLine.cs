using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Finish line");
            Invoke("ReloadScene", 1f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
