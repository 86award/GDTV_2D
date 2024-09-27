using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        int numScenePesists = FindObjectsByType<ScenePersist>(FindObjectsSortMode.InstanceID).Length;
        if (numScenePesists > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
