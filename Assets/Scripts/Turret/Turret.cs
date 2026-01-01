using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Turret : MonoBehaviour
{
    private List<Projectile.Pool> _projectilesPool = new List<Projectile.Pool>();

    private Projectile.Pool _fireballPool;
    private Projectile.Pool _iceballPool;

    private TurretDataSO _data;

    private PlayerMovement _player;

    [Header("Attack Settings")]
    [SerializeField] private Transform _attackPosition;
    
    private int _projectileCount;

    private float _attackInterval;
    private float _repairTime;

    private bool _canAttack = true;

    [Inject]
    public void Construct(
        [Inject(Id = GameConstant.TurretPrefab.FIREBALL)] Projectile.Pool fireballPool,
        [Inject(Id = GameConstant.TurretPrefab.ICEBALL)] Projectile.Pool iceballPool,
        TurretDataSO data,
        PlayerMovement player
        )
    {
        _fireballPool = fireballPool;
        _iceballPool = iceballPool;
        _data = data;
        _player = player;

        InitializeProjectiles();
    }
    private void InitializeProjectiles()
    {
        _projectilesPool.Clear();

        _projectilesPool.Add(_fireballPool);
        _projectilesPool.Add(_iceballPool);

        _projectileCount = GetRandomProjectileCount();
        _attackInterval = GetRandomIntervalTime();
    }
    private void Update()
    {
        if (_canAttack)
            HandleAttack();
        else
            HandleRepair();
    }
    private void HandleAttack()
    {
        RotateTowardsPlayer();

        _attackInterval -= Time.deltaTime;
        if (_attackInterval < 0)
        {
            CreateRandomProjectile();
            DecreaseProjectileCount();
            _attackInterval = GetRandomIntervalTime();
        }
    }
    private void HandleRepair()
    {
        _repairTime -= Time.deltaTime;
        if (_repairTime < 0)
        {
            _canAttack = true;
            ResetProjectileCount();
        }
    }
    private void ResetProjectileCount() => _projectileCount = GetRandomProjectileCount();
    private void CreateRandomProjectile()
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
    private void RotateTowardsPlayer()
    {
        var rotateDirection = _player.transform.position - transform.position;
        rotateDirection.y = 0;

        if(rotateDirection != Vector3.zero)
        {
            Quaternion playerRotation = Quaternion.LookRotation(rotateDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, _data.RotationSpeed * Time.deltaTime);
        }
    }
    private void DecreaseProjectileCount()
    {
        _projectileCount--;

        if (_projectileCount <= 0)
        {
            _canAttack = false;
            _repairTime = _data.RepairTime;
        }
    }
    private float GetRandomIntervalTime() => GameUtils.GetRandomFloat(_data.MinAttackInterval,_data.MaxAttackInterval);
    private int GetRandomProjectileCount() => GameUtils.GetRandomInt(_data.MinProjectileCount,_data.MaxProjectileCount);
}
