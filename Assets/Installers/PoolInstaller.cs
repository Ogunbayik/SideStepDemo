using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [Header("Prefab Settings")]
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _iceballPrefab;
    [Header("Pool Settings")]
    [SerializeField] private int _poolSize;

    public override void InstallBindings()
    {
        Container.BindMemoryPool<Projectile, Projectile.Pool>()
            .WithId(GameConstant.TurretPrefab.FIREBALL)
            .WithInitialSize(_poolSize)
            .FromComponentInNewPrefab(_fireballPrefab)
            .UnderTransformGroup(GameConstant.TurretPrefab.ATTACK_PREFABS_GROUP);

        Container.BindMemoryPool<Projectile, Projectile.Pool>()
            .WithId(GameConstant.TurretPrefab.ICEBALL)
            .WithInitialSize(_poolSize)
            .FromComponentInNewPrefab(_iceballPrefab)
            .UnderTransformGroup(GameConstant.TurretPrefab.ATTACK_PREFABS_GROUP);
    }
}