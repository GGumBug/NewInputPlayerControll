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
    #endregion

    #region PublisherMethod
    public void Add(InputType type, IObserver observer)
    {
        switch (type)
        {
            case InputType.Move:
                playerMove = observer;
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
        }
    }
    #endregion

    public Vector3 CurScreenPos { get; private set; }
    private IObserver playerMove;

    private void OnEnable()
    {
        _ydInput = new YDInput();
        _moveDestPos = _ydInput.Player.MoveDestPos;
        _move = _ydInput.Player.Move;
        _moveDestPos.Enable();
        _move.Enable();

        _moveDestPos.started += (context) => ScreenPosStarted(context);
        _moveDestPos.performed += (context) => ScreenPosPerformed(context);
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

    void PressCanceled(InputAction.CallbackContext context)
    {
        playerMove.Update();
    }
}
