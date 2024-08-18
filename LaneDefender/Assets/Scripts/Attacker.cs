using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 15f)]
    [SerializeField] private float currentSpeed;

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
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
