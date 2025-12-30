using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prefab Data", menuName = "ScriptableObject/Prefab Data")]
public class ProjectileDataSO : ScriptableObject
{
    [Header("Projectile Settings")]
    [SerializeField] private string _name;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _damage;

    public string Name => _name;
    public float MovementSpeed => _movementSpeed;
    public float Damage => _damage;
}
