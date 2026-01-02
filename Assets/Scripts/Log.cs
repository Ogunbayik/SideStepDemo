using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Log : MonoBehaviour
{
    private float _movementSpeed;


    private void Update() => HandleMovement();
    private void HandleMovement()
    {
        //Add DORotate for object
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }

    public class Factory : PlaceholderFactory<Log> { }
}
