using UnityEngine;
using TD.Factory;

[CreateAssetMenu(fileName = "New Bullet Factory", menuName = "Factory/Bullet")]
public class BulletFactorySO : FactorySO<BasicBullet>
{
    [SerializeField] BasicBullet _prefab = default;
    public override BasicBullet Create()
    {
        return Instantiate(_prefab);
    }
}