using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZoomInAndOut : MonoBehaviour
{
    private InputManager _inputM;
    private InputAction _zoom;
    private InputAction _touch0Pos;
    private InputAction _touch1Pos;
    private InputAction _touch0Press;
    private InputAction _touch1Press;
    public CinemachineFreeLook playerCam;
    Vector2 cameraZoomValue;
    float prevMagnitude = 0;
    int touchCount = 0;
    private float zoomSpeed = 0.1f;

    private void OnEnable()
    {
        playerCam = GetComponent<CinemachineFreeLook>();
        _inputM = InputManager.Instance;
        _zoom = _inputM.YDInput.Camera.Zoom;
        _touch0Pos = _inputM.YDInput.Camera.Touch0Pos;
        _touch1Pos = _inputM.YDInput.Camera.Touch1Pos;
        _touch0Press = _inputM.YDInput.Camera.Touch0Press;
        _touch1Press = _inputM.YDInput.Camera.Touch1Press;
        _zoom.performed += ZoomPerformed;
        _touch1Pos.performed += Touch1Performed;
        _touch0Press.performed += _ => touchCount++;
        _touch1Press.performed += _ => touchCount++;
        _touch0Press.canceled += _ =>
        {
            touchCount--;
            prevMagnitude = 0;
        };
        _touch1Press.canceled += _ =>
        {
            touchCount--;
            prevMagnitude = 0;
        };

        _zoom.Enable();
        _touch0Pos.Enable();
        _touch1Pos.Enable();
        _touch0Press.Enable();
        _touch1Press.Enable();
    }

    private void OnDisable()
    {
        _zoom.Disable();
        _touch0Pos.Disable();
        _touch1Pos.Disable();
        _touch0Press.Disable();
        _touch1Press.Disable();
    }

    void ZoomPerformed(InputAction.CallbackContext context)
    {
        _inputM.CurrentState.CanZoom();
        cameraZoomValue = _zoom.ReadValue<Vector2>();
        Zoom(cameraZoomValue.y * zoomSpeed);
    }

    void Touch1Performed(InputAction.CallbackContext context)
    {
        if (touchCount < 2)
            return;

        _inputM.CurrentState.CanZoom();
        var magnitude = (_touch0Pos.ReadValue<Vector2>() - _touch1Pos.ReadValue<Vector2>()).magnitude;
        if (prevMagnitude == 0)
            prevMagnitude = magnitude;
        
        var difference = magnitude - prevMagnitude;
        prevMagnitude = magnitude;

        Zoom(difference * zoomSpeed);
    }

    public void Zoom(float yAxis)
    {
        if (yAxis < 0 && playerCam.m_Orbits[1].m_Radius < 10)
        {
            playerCam.m_Orbits[0].m_Radius += zoomSpeed;
            playerCam.m_Orbits[1].m_Radius += zoomSpeed;
            playerCam.m_Orbits[2].m_Radius += zoomSpeed;
        }
        else if (yAxis > 0 && playerCam.m_Orbits[0].m_Radius > 2)
        {
            playerCam.m_Orbits[0].m_Radius -= zoomSpeed;
            playerCam.m_Orbits[1].m_Radius -= zoomSpeed;
            playerCam.m_Orbits[2].m_Radius -= zoomSpeed;
        }
    }
}
