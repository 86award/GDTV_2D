using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnDefender : MonoBehaviour
{
    Defender defender = null;
    [SerializeField] Collider2D areaCollider;

    private void Awake()
    {
        //areaCollider = GetComponent<BoxCollider2D>();// as Collider2D;
    }

    //Called in the DefenderButton script to set the prefab to be placed
    public void SetSelectedDefnder(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    //There's a magic number here for the z co-ord
    private Vector3 ClickedLocation()
    {
        Vector3 rawMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);
        Vector3 uiMousePos = Camera.main.ScreenToWorldPoint(rawMousePos);
        return uiMousePos;
    }

    void OnAttack()
    {
        Vector3 modifiedWorldSpace = ClickedLocation() + new Vector3(-5, -3, 0);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, modifiedWorldSpace);
        Debug.DrawRay(Camera.main.transform.position, modifiedWorldSpace, Color.red, 30f);
        Debug.Log(hit.collider.gameObject.tag);

        if (true)//hit.collider.gameObject.tag == "Game Area")
        {
            if (areaCollider.OverlapPoint(ClickedLocation()))
            {
                AttemptToPlaceDefenderAt(ClickedLocation());
            } 
        }
    }

    public void AttemptToPlaceDefenderAt(Vector3 gridPos)
    {
        var starDisplay = FindAnyObjectByType<StarDisplay>();
        int defenderCost = defender.StarCost;
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnUnitAtClick(gridPos);
            starDisplay.SubtractStars(defenderCost);
        }
    }
    
    private void SpawnUnitAtClick(Vector3 spawnLocation)
    {

        Vector3 targetGrid = SpawnLocationAsGridRef(spawnLocation);
        Instantiate(defender, targetGrid, Quaternion.identity);
    }
    
    private Vector3 SpawnLocationAsGridRef(Vector3 screenClickLocation)
    {
        int newX = Mathf.RoundToInt(screenClickLocation.x);
        int newY = Mathf.RoundToInt(screenClickLocation.y);
        Vector3 roundedLocation = new Vector3(newX, newY, screenClickLocation.z);
        return roundedLocation;
    }
}
