using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InputManager : Singleton<InputManager>
{
    #region InputAction
    private YDInput _ydInput;
    private InputAction _moveDestPos;
    private InputAction _move;

    public InputActionReference XYAxis { get; set; }
    #endregion

    #region PublisherMethod
    public void Add(InputType type, IObserver observer)
    {
        switch (type)
        {
            case InputType.Move:
                playerMove = observer;
                break;
            case InputType.Drag:
                drag = observer;
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
            case InputType.Drag:
                drag = observer;
                break;
        }
    }
    #endregion

    IObserver playerMove;
    IObserver drag;
    Vector3 startPos;
    Coroutine dragCoroutine;

    public Vector3 CurScreenPos { get; private set; }
    public bool IsDrage { get; private set; }


    private void OnEnable()
    {
        _ydInput = new YDInput();
        _moveDestPos = _ydInput.Player.MoveDestPos;
        _move = _ydInput.Player.Move;
        XYAxis = InputActionReference.Create(_ydInput.Player.MoveDestPos);

        _moveDestPos.Enable();
        _move.Enable();

        _moveDestPos.started += (context) => ScreenPosStarted(context);
        _moveDestPos.performed += (context) => ScreenPosPerformed(context);
        _move.started += (context) => PressStarted(context);
        _move.performed += (context) => PressPerformed(context);
        _move.canceled += (context) => PressCanceled(context);
    }

    private void OnDisable()
    {
        _moveDestPos.Disable();
        _move.Disable();
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
        Debug.Log($"startPos : {startPos}");
        Debug.Log($"CurScreenPos : {CurScreenPos}");
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

    IEnumerator CheckDrag()
    {
        Debug.Log("CheckDrag");
        while (true) 
        {
            if (Vector3.Distance(startPos, CurScreenPos) > 0.1f)
            {
                IsDrage = true;
                yield break;
            }

            yield return null;
        }
    }
}
