using UnityEngine;

public class Lizard : MonoBehaviour
{
    [SerializeField] int livesToSubtract;

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
        else if (otherObject.GetComponent<Base>())
        {
            FindAnyObjectByType<LivesDisplay>().SubtractLives(livesToSubtract);
        }
    }
}
