using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    #region InputAction
    private YDInput _ydInput;
    private InputAction _moveDestPos;
    private InputAction _press;
    private InputAction _zoom;

    public InputActionReference CameraXYAxis { get; set; }
    public InputActionReference CameraZoom { get; set; }
    #endregion

    #region PublisherMethod
    IObserver playerMove;
    IObserver zoom;

    public void Add(InputType type, IObserver observer)
    {
        switch (type)
        {
            case InputType.Move:
                playerMove = observer;
                break;
            case InputType.Zoom:
                zoom = observer;
                break;
        }
    }

    public void Delete(InputType type, IObserver observer)
    {
        switch (type)
        {
            case InputType.Move:
                playerMove = null;
                break;
            case InputType.Zoom:
                zoom = observer;
                break;
        }
    }
    #endregion

    Vector3 startPos;
    float minDragDist = 5f;
    Coroutine dragCoroutine;

    public Vector3 CurScreenPos { get; private set; }
    public Vector2 CameraZoomValue { get; private set; }
    public bool IsDrage { get; private set; }


    private void OnEnable()
    {
        _ydInput = new YDInput();
        _moveDestPos = _ydInput.Player.MoveDestPos;
        _press = _ydInput.Player.Move;
        _zoom = _ydInput.Camera.Zoom;
        CameraXYAxis = InputActionReference.Create(_ydInput.Camera.CameraRotation);
        CameraZoom = InputActionReference.Create(_ydInput.Camera.Zoom);

        _moveDestPos.Enable();
        _press.Enable();
        _zoom.Enable();

        _moveDestPos.started += (context) => ScreenPosStarted(context);
        _moveDestPos.performed += (context) => ScreenPosPerformed(context);
        _press.started += (context) => PressStarted(context);
        _press.performed += (context) => PressPerformed(context);
        _press.canceled += (context) => PressCanceled(context);
        _zoom.performed += (context) => ZoomPerformed(context);
    }

    private void OnDisable()
    {
        _moveDestPos.Disable();
        _press.Disable();
        _zoom.Disable();
    }

    void ScreenPosStarted(InputAction.CallbackContext context)
    {
        CurScreenPos = context.ReadValue<Vector2>();
    }

    void ScreenPosPerformed(InputAction.CallbackContext context)
    {
        CurScreenPos = context.ReadValue<Vector2>();
    }

    void PressStarted(InputAction.CallbackContext context)
    {
        startPos = CurScreenPos;
    }

    void PressPerformed(InputAction.CallbackContext context)
    {
        dragCoroutine = StartCoroutine("CheckDrag");
    }

    void PressCanceled(InputAction.CallbackContext context)
    {
        if (IsDrage)
        {
            IsDrage = false;
            return;
        }

        StopCoroutine(dragCoroutine);
        playerMove.Update();
    }

    void ZoomPerformed(InputAction.CallbackContext context)
    {
        CameraZoomValue = _zoom.ReadValue<Vector2>();
        zoom.Update();
    }

    IEnumerator CheckDrag()
    {
        while (true) 
        {
            Debug.Log($"startPos : {startPos}");
            Debug.Log($"CurScreenPos : {CurScreenPos}");
            if (Vector2.Distance(startPos, CurScreenPos) > 0.1f)
            {
                IsDrage = true;
                yield break;
            }

            yield return null;
        }
    }
}
