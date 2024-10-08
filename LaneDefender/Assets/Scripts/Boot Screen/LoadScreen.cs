using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Load());
    }

    public IEnumerator Load()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
