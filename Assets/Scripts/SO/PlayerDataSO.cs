using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObject/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;
    [Header("Health Settings")]
    [SerializeField] private int _maximumHealth;


    public float MovementSpeed => _movementSpeed;
    public int MaximumHealth => _maximumHealth;
}
