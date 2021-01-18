using UnityEngine;
using TD.Factory;
using TD.Pool;

[CreateAssetMenu(fileName = "New Bullet Pool", menuName = "Pool/Bullet")]
public class BulletPoolSO : ComponentPoolSO<BasicBullet>
{
    [SerializeField] BulletFactorySO _factory;
    public override IFactory<BasicBullet> Factory
    {
        get => _factory; 
        set => _factory = value as BulletFactorySO;
    }
}