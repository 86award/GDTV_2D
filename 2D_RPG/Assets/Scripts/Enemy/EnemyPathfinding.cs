using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private Rigidbody2D rb;
    private Vector2 movementDir;
    private Knockback knockback;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<Knockback>();

    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (knockback.GettingKnockedBack) return;
            // the order is critical so that you multiply movement before adding to position
            rb.MovePosition((moveSpeed * Time.fixedDeltaTime) * movementDir + rb.position);
    }

    public void GetMoveDir(Vector2 targetPostion)
    {
        movementDir = targetPostion;
    }

}
