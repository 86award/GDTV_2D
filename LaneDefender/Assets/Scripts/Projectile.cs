using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3;
    [SerializeField] Vector3 rotationAmount = new Vector3(0, 0, -360);

    private void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * projectileSpeed), Space.World);
        transform.Rotate(rotationAmount * Time.deltaTime);
    }
}