using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] int livesToSubtract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
        else if (otherObject.GetComponent<Base>())
        {
            FindAnyObjectByType<LivesDisplay>().SubtractLives(livesToSubtract);
        }
    }
}
