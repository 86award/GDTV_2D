using UnityEngine;

public class AttackerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    [SerializeField] private int health;

    private void Awake()
    {
        health = startingHealth;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
