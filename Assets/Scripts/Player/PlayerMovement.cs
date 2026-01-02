using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    private IInputService _inputService;
    private PlayerDataSO _dataSO;

    private Vector3 _movementDirection;

    [Inject]
    public void Construct(IInputService inputService, PlayerDataSO dataSO)
    {
        _inputService = inputService;
        _dataSO = dataSO;
    }
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
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

        _characterController.SimpleMove(_movementDirection * _dataSO.MovementSpeed);
    }

}
