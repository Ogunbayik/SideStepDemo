using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _iceballPrefab;
    [Header("Data Settings")]
    [SerializeField] private ProjectileDataSO _fireballData;
    [SerializeField] private ProjectileDataSO _iceballData;
    [Header("Pool Settings")]
    [SerializeField] private int _poolSize;

    public override void InstallBindings()
    {
        Container.BindMemoryPool<Projectile, Projectile.Pool>()
            .WithId(GameConstant.PoolPrefab.FIREBALL_PROJECTILE)
            .WithInitialSize(_poolSize)
            .FromComponentInNewPrefab(_fireballPrefab)
            .UnderTransformGroup(GameConstant.PoolPrefab.PROJECTILE_PREFAB_GROUP)
            .OnInstantiated<Projectile>((ctx, projectile) => projectile.Construct(_fireballData));

        Container.BindMemoryPool<Projectile, Projectile.Pool>()
            .WithId(GameConstant.PoolPrefab.ICEBALL_PROJECTILE)
            .WithInitialSize(_poolSize)
            .FromComponentInNewPrefab(_iceballPrefab)
            .UnderTransformGroup(GameConstant.PoolPrefab.PROJECTILE_PREFAB_GROUP)
            .OnInstantiated<Projectile>((ctx, projectile) => projectile.Construct(_iceballData));
    }
}