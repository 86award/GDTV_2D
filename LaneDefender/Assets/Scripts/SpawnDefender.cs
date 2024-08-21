using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnDefender : MonoBehaviour
{
    [SerializeField] GameObject defender;

    void OnAttack()
    {
        SpawnUnitAtClick(ClickedLocation());
    }

    private Vector3 ClickedLocation()
    {
        Vector3 rawMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 uiMousePos = Camera.main.ScreenToWorldPoint(rawMousePos);
        return uiMousePos;
    }
    
    private void SpawnUnitAtClick(Vector3 spawnLocation)
    {
        Vector3 targetGrid = SpawnLocationAsGridRef(spawnLocation);
        Instantiate(defender, targetGrid, Quaternion.identity);
    }  

    private Vector3 SpawnLocationAsGridRef(Vector3 clickLocation)
    {
        int newX = Mathf.RoundToInt(clickLocation.x);
        int newY = Mathf.RoundToInt(clickLocation.y);
        Vector3 roundedLocation = new Vector3(newX, newY, clickLocation.z);
        return roundedLocation;
    }
}
