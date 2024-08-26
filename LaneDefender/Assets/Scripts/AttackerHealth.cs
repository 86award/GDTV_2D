using System;
using UnityEngine;

public class AttackerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] private int health;
    [SerializeField] private GameObject collisionVFX;

    private void Awake()
    {
        health = startingHealth;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerCollisionVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerCollisionVFX()
    {
        GameObject vfxObject = Instantiate(collisionVFX, transform.position, transform.rotation);
        Destroy(vfxObject, 1f);
    }
}
