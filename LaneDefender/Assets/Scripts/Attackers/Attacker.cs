using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 15f)]
    [SerializeField] private float currentSpeed;
    GameObject currentTarget;

    private void Awake()
    {
        LevelController levelController = GetComponent<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerSpawned();
        }
    }

    private void OnDestroy()
    {
        LevelController levelController = GetComponent<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerDestroyed();
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * (currentSpeed * Time.deltaTime));
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    void ActivateCollision()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) return;
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
