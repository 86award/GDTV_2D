using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    private bool isSpawning = true;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] attackerArray;

    IEnumerator Start()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void SpawnAttacker()
    {
        int index = Random.Range(0, attackerArray.Length);
        Spawn(attackerArray[index]);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform; //set the attacker parent to this gameobject
    }
}
