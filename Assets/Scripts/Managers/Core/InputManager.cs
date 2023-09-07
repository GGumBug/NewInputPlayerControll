using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    #region InputAction
    public YDInput YDInput { get; private set; }

    private InputAction _moveDestPos;
    private InputAction _press;
    #endregion

    #region PublisherMethod
    IObserver playerMove;
    public IInputState CurrentState { get; set; }
    public IInputState WaitState { get; set; }
    public IInputState ClickState { get; set; }
    public IInputState CameraDragState { get; set; }
    public IInputState CameraZoomState { get; set; }

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

    public void SetState(IInputState inputState)
    {
        CurrentState = inputState;
    }

    public bool CheckState(IInputState inputState)
    {
        if (CurrentState == inputState)
            return true;
        else
            return false;
    }
    #endregion

    Vector3 startPos;
    float minDragDist = 50f;
    Coroutine dragCoroutine;

    public Vector3 CurScreenPos { get; private set; }
    public bool IsDrage { get; private set; }


    private void OnEnable()
    {
        WaitState = new WaitInput(this);
        ClickState = new ClickInput(this);
        CameraDragState = new CameraDrag(this);
        CameraZoomState = new CameraZoom(this);
        CurrentState = WaitState;


        YDInput = new YDInput();
        _moveDestPos = YDInput.Player.MoveDestPos;
        _press = YDInput.Player.Move;

        _moveDestPos.Enable();
        _press.Enable();

        _moveDestPos.started += (context) => ScreenPosStarted(context);
        _moveDestPos.performed += (context) => ScreenPosPerformed(context);
        _press.started += (context) => PressStarted(context);
        _press.performed += (context) => PressPerformed(context);
        _press.canceled += (context) => PressCanceled(context);
    }

    private void OnDisable()
    {
        _moveDestPos.Disable();
        _press.Disable();
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
        CurrentState.CanClick();
    }

    void PressPerformed(InputAction.CallbackContext context)
    {
        dragCoroutine = StartCoroutine("CheckDrag");
    }

    void PressCanceled(InputAction.CallbackContext context)
    {
        if (!CurrentState.CanClick())
        {
            CurrentState = WaitState;
            return;
        }

        StopCoroutine(dragCoroutine);
        playerMove.Update();
    }

    IEnumerator CheckDrag()
    {
        while (true) 
        {
            if (Vector2.Distance(startPos, CurScreenPos) > minDragDist)
            {
                CurrentState = CameraDragState;
                yield break;
            }

            yield return null;
        }
    }
}
