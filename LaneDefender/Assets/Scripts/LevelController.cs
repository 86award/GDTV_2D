using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        levelCompleteCanvas.SetActive(true);
        yield return new WaitForSeconds(4f);
        FindAnyObjectByType<LoadScreen>().Load();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsByType<AttackerSpawner>(FindObjectsSortMode.InstanceID);
        foreach (var spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
