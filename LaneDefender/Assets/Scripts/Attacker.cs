using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 15f)]
    [SerializeField] private float currentSpeed;
    GameObject currentTarget;

    void Update()
    {
        transform.Translate(Vector3.left * (currentSpeed * Time.deltaTime));
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
}
