using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float facingDirection;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
        facingDirection = player.transform.localScale.x;
        transform.localScale = new Vector2(facingDirection, 1);
    }

    private void Update()
    {
        myRigidbody.linearVelocityX = bulletSpeed * facingDirection;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
