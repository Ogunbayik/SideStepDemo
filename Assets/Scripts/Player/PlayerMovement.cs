using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    private IInputService _inputService;

    private Vector3 _movementDirection;

    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var horizontal = _inputService.GetHorizontal();
        var vertical = _inputService.GetVertical();

        _movementDirection.Set(horizontal, 0f, vertical);

        if (_movementDirection.sqrMagnitude > 1f)
            _movementDirection.Normalize();

        _characterController.SimpleMove(_movementDirection * _movementSpeed);
    }
}
