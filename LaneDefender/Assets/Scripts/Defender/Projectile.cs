using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3;
    [SerializeField] Vector3 rotationAmount = new Vector3(0, 0, -360);
    [SerializeField] int projectileDmg = 50;
    //[SerializeField] ParticleSystem collisionFX;

    private void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * projectileSpeed), Space.World);
        transform.Rotate(rotationAmount * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            Destroy(gameObject);
            //Instantiate(collisionFX, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<Health>().DealDamage(projectileDmg);
        }
    }
}
