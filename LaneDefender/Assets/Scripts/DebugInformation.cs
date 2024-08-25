using TMPro;
using UnityEngine;

public class DebugInformation : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString();
    }
}
