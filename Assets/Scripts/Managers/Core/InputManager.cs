using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private Vector3 curScreenPos;
    private IObserver playerMove;

    private void OnEnable()
    {
        _ydInput = new YDInput();
        _moveDestPos = _ydInput.Player.MoveDestPos;
        _move = _ydInput.Player.Move;
        _moveDestPos.Enable();
        _move.Enable();

        _moveDestPos.started += (context) => GetDestPos(context);
        _move.canceled += (context) => PressCanceled(context);
    }

    private void OnDisable()
    {
        _moveDestPos.Disable();
        _move.Disable();
    }

    public Vector3 GetDestWorldPos(Transform moveTarget)
    {
        float y = Camera.main.WorldToScreenPoint(moveTarget.position).y;
        return Camera.main.ScreenToWorldPoint(curScreenPos + new Vector3(0, y, 0));
    }

    void GetDestPos(InputAction.CallbackContext context)
    {
        curScreenPos = context.ReadValue<Vector2>();
    }

    void PressCanceled(InputAction.CallbackContext context)
    {
        playerMove.Update();
    }
}
