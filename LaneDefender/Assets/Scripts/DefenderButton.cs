using NUnit.Framework.Constraints;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    Collider2D areaCollider;
    SpriteRenderer sr;

    private void Awake()
    {
        areaCollider = GetComponent<BoxCollider2D>();// as Collider2D;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnAttack()
    {
        if (areaCollider.OverlapPoint(ClickedLocation()))
        {
            var defenderButtons = FindObjectsByType<DefenderButton>(FindObjectsSortMode.InstanceID);
            foreach (DefenderButton defenderButton in defenderButtons)
            {
                defenderButton.sr.color = new Color32(70, 56, 56, 255);
            }
            sr.color = Color.white;

            //call spawner method and pass serf
            FindFirstObjectByType<SpawnDefender>().SetSelectedDefnder(defenderPrefab);
        }
    }
    private Vector3 ClickedLocation()
    {
        Vector3 rawMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 uiMousePos = Camera.main.ScreenToWorldPoint(rawMousePos);
        return uiMousePos;
    }
}
