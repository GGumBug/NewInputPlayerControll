using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProviderWhenDrag : MonoBehaviour, AxisState.IInputAxisProvider
{
    InputActionReference XYAxis;

    private void Start()
    {
        XYAxis = InputManager.Instance.XYAxis;
    }

    public float GetAxisValue(int axis)
    {
        if (!InputManager.Instance.IsDrage)
            return 0;

        switch (axis)
        {
            case 0: return XYAxis.action.ReadValue<Vector2>().x;
            case 1: return XYAxis.action.ReadValue<Vector2>().y;
            default: return 0;
        }
    }
}
