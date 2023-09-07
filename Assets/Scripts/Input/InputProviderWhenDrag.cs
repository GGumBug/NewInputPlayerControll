using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProviderWhenDrag : MonoBehaviour, AxisState.IInputAxisProvider
{
    InputManager _inputM;
    InputAction _camerarotation;

    private void OnEnable()
    {
        _inputM = InputManager.Instance;
        _camerarotation = _inputM.YDInput.Camera.CameraRotation;
        _camerarotation.Enable();
    }

    private void OnDisable()
    {
        _camerarotation.Disable();
    }

    public float GetAxisValue(int axis)
    {
        if (!_inputM.CheckState(_inputM.CameraDragState))
            return 0;

        switch (axis)
        {
            //InputAction Vector2 Delta ¼³Á¤ Position ¾Æ´Ô
            case 0: return _camerarotation.ReadValue<Vector2>().x;
            case 1: return _camerarotation.ReadValue<Vector2>().y;
            default: return 0;
        }
    }
}
