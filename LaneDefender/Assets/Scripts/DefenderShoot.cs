using System;
using UnityEngine;

public class DefenderShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;
    Animator animator;
    AttackerSpawner myLaneSpawner;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsByType<AttackerSpawner>(FindObjectsSortMode.None);
        foreach (AttackerSpawner spawner in attackerSpawners) 
        {
            //check that spawners are on the same lane as this defender
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough) myLaneSpawner = spawner;
        }
    }

    private void Fire()
    {
        Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
    }

    private void Update()
    {
        if (AttackerIsInLane()) animator.SetBool("isAttacking", true);
        else animator.SetBool("isAttacking", false);
    }

    private bool AttackerIsInLane()
    {
        if (myLaneSpawner.transform.childCount > 0) return true;
        else return false;
    }
}
