using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour, IPoolable<IMemoryPool>
{
    private IMemoryPool _pool;

    [Header("Data Settings")]
    [SerializeField] private ProjectileDataSO _dataSO;
    public void OnSpawned(IMemoryPool pool)
    {
        _pool = pool;
    }
    public void OnDespawned()
    {
        _pool = null;
    }

    public void ReturnToPool()
    {
        _pool.Despawn(this);
    }
    private void Update() => HandleMovement();
    private void HandleMovement() => transform.Translate(Vector3.forward * _dataSO.MovementSpeed * Time.deltaTime);

    public class Pool : MonoPoolableMemoryPool<IMemoryPool, Projectile> { }
}
