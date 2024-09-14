using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnDefender : MonoBehaviour
{
    [SerializeField] GameObject defenderParent;
    Defender defender;
    BoxCollider2D areaCollider;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Awake()
    {
        areaCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    //There's a magic number here for the z co-ord
    private Vector2 ClickedLocation()
    {
        Vector2 rawMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);//, 20f);
        Vector2 uiMousePos = Camera.main.ScreenToWorldPoint(rawMousePos);
        return uiMousePos;
    }

    void OnAttack()
    {
        //Vector3 modifiedWorldSpace = ClickedLocation() + new Vector2(-5, -3);//, 11f); //compensate for camera offset

        //Something is happening here to make the ray fire straight forward from the camera like 0,0,1
        //RaycastHit2D hit = Physics2D.Raycast((Vector2)Camera.main.transform.position, modifiedWorldSpace);
        //Debug.DrawRay(Camera.main.transform.position, modifiedWorldSpace, Color.red, 30f);

        //what if I shoot from the mouse position foward
        //RaycastHit2D hit = Physics2D.Raycast(modifiedWorldSpace, Vector3.forward);
        //Debug.DrawRay(modifiedWorldSpace, hit.point, Color.red, 30f);

        //or perhaps just from the raw clicked location
        RaycastHit2D hit = Physics2D.Raycast(ClickedLocation(), Vector3.forward);
        Debug.DrawRay((Vector3)ClickedLocation() + new Vector3(0, 0, -10), (Vector3)hit.point + new Vector3(0,0,10f), Color.red, 30f);

        if (hit.collider == areaCollider)
        {
            //if (areaCollider.OverlapPoint(ClickedLocation()))
            //{
                AttemptToPlaceDefenderAt(ClickedLocation());
            //} 
        }
    }

    public void AttemptToPlaceDefenderAt(Vector2 gridPos)
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
        Defender defender = this.defender;
        Instantiate(defender, targetGrid, Quaternion.identity);

        //new as 14/09
        defender.transform.parent = defenderParent.transform;
    }
    
    private Vector3 SpawnLocationAsGridRef(Vector3 screenClickLocation)
    {
        int newX = Mathf.RoundToInt(screenClickLocation.x);
        int newY = Mathf.RoundToInt(screenClickLocation.y);
        Vector3 roundedLocation = new Vector3(newX, newY, screenClickLocation.z);
        return roundedLocation;
    }

    //Called in the DefenderButton script to set the prefab to be placed
    public void SetSelectedDefnder(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
}