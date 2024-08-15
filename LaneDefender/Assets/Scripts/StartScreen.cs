using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseApplication(int value)
    {
        SceneManager.LoadScene(value);
    }
}
