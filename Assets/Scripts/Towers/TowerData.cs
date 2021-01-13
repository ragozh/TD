using UnityEngine;

public abstract class TowerData : MonoBehaviour
{
    public abstract float AttackDamage { get; set; }
    public abstract float AttackSpeed { get; set; }
    public abstract float AttackRange { get; set; }

    public virtual float RotationSpeed { get; set; }
}
public enum AttackType { Pierce, Blast }
