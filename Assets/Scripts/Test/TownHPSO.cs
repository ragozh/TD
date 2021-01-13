using UnityEngine;

[CreateAssetMenu(menuName = "TownHP")]
public class TownHPSO : ScriptableObject
{
    [Range(0, 150)]
    public float HP;
}