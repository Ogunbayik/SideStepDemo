using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret Data", menuName = "ScriptableObject/Turret Data")]
public class TurretDataSO : ScriptableObject
{
    [Header("Rotation Settings")]
    [SerializeField] private float _rotationSpeed;
    [Header("Attack Settings")]
    [SerializeField] private float _minAttackInterval;
    [SerializeField] private float _maxAttackInterval;
    [SerializeField] private int _minProjectileCount;
    [SerializeField] private int _maxProjectileCount;
    [Header("Repair Settings")]
    [SerializeField] private float _repairTime;

    public float RotationSpeed => _rotationSpeed;
    public float MinAttackInterval => _minAttackInterval;
    public float MaxAttackInterval => _maxAttackInterval;
    public int MinProjectileCount => _minProjectileCount;
    public int MaxProjectileCount => _maxProjectileCount;
    public float RepairTime => _repairTime;
}
