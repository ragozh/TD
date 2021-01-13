using UnityEngine;

public abstract class MonsterData : MonoBehaviour
{
    public abstract float Damage { get; set; }
    public abstract float MaxHP { get; set; } 
    public abstract float Movespeed { get; set; }
    public abstract float ArmorValue { get; set; }
}
public enum ArmorType { Light, Heavy }