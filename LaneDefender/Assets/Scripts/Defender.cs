using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost;

    public void AddStars(int value)
    {
        FindFirstObjectByType<StarDisplay>().AddStars(value);
    }

    public int StarCost { get { return starCost; } }
}
