using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Turret : MonoBehaviour
{
    private Projectile.Pool _fireballPool;
    private Projectile.Pool _iceballPool;

    private List<Projectile.Pool> _projectilesPool = new List<Projectile.Pool>();

    [Header("Attack Settings")]
    [SerializeField] private Transform _attackPosition;

    [Inject]
    public void Construct(
        [Inject(Id = GameConstant.TurretPrefab.FIREBALL)]Projectile.Pool fireballPool,
        [Inject(Id = GameConstant.TurretPrefab.ICEBALL)]Projectile.Pool iceballPool
        )
    {
        _fireballPool = fireballPool;
        _iceballPool = iceballPool;
    }
    private void Start()
    {
        InitializeProjectiles();

        AttackPrefab();
    }

    private void InitializeProjectiles()
    {
        _projectilesPool.Clear();

        _projectilesPool.Add(_fireballPool);
        _projectilesPool.Add(_iceballPool);
    }

    private void AttackPrefab()
    {
        Projectile projectile = GetRandomProjectile();
        projectile.transform.position = _attackPosition.position;
        projectile.transform.rotation = _attackPosition.rotation;
    }
    private Projectile GetRandomProjectile()
    {
        var randomIndex = Random.Range(0, _projectilesPool.Count);
        var randomPool = _projectilesPool[randomIndex];
        Projectile randomProjectile = randomPool.Spawn(randomPool);

        return randomProjectile;
    }

}
