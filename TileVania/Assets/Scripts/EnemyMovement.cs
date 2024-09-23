using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D platformDetector;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        platformDetector = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        myRigidbody.linearVelocityX = moveSpeed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(Mathf.Sign(moveSpeed), 1);
    }
}
