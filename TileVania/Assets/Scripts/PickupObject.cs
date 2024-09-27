using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] AudioClip coinPickup;
    [SerializeField] int coinValue;
    bool wasCollected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindAnyObjectByType<GameSession>().AddToPoints(coinValue);
            AudioSource.PlayClipAtPoint(coinPickup, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
