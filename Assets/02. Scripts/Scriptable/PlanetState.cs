using UnityEngine;

[CreateAssetMenu(menuName = "PlanetState")]
public class PlanetState : ScriptableObject
{
    public float temperature = 0f;
    public float oxyLevel = 0f;
    public int landLevel = 1;
    public bool isWater = false;
}