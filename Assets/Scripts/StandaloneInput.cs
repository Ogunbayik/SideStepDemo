using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaloneInput : IInputService
{
    public float GetHorizontal() => Input.GetAxis(GameConstant.PlayerInput.HORIZONTAL_INPUT);

    public float GetVertical() => Input.GetAxis(GameConstant.PlayerInput.VERTICAL_INPUT);
}
