using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystemCrash;
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Ground")
    //     {
    //         Debug.Log("Crash");
    //     }
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Crash");
            Invoke("ReloadScene", 1f);
            particleSystemCrash.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
