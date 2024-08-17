using UnityEngine;

public class DefenderShoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;

    private void Fire()
    {
        Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
    }
}
