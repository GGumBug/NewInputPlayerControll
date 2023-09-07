using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputState
{
    bool CanWait();
    bool CanClick();
    bool CanDrag();
    bool CanZoom();
}

public class WaitInput : IInputState
{
    InputManager input;

    public WaitInput(InputManager input)
    {
        this.input = input;
    }

    public bool CanDrag()
    {
        return false;
    }

    public bool CanClick()
    {
        input.SetState(input.ClickState);
        return true;
    }

    public bool CanZoom()
    {
        return false;
    }

    public bool CanWait()
    {
        return true;
    }
}

public class ClickInput : IInputState
{
    InputManager input;

    public ClickInput(InputManager input)
    {
        this.input = input;
    }

    public bool CanDrag()
    {
        input.SetState(input.CameraDragState);
        return true;
    }

    public bool CanClick()
    {
        return true;
    }

    public bool CanZoom()
    {
        input.SetState(input.CameraZoomState);
        return true;
    }

    public bool CanWait()
    {
        input.SetState(input.WaitState);
        return true;
    }
}

public class CameraDrag : IInputState
{
    InputManager input;

    public CameraDrag(InputManager input)
    {
        this.input = input;
    }

    public bool CanClick()
    {
        return false;
    }

    public bool CanZoom()
    {
        input.SetState(input.CameraZoomState);
        return true;
    }

    public bool CanDrag()
    {
        return true;
    }

    public bool CanWait()
    {
        input.SetState(input.WaitState);
        return true;
    }
}

public class CameraZoom : IInputState
{
    InputManager input;

    public CameraZoom(InputManager input)
    {
        this.input = input;
    }

    public bool CanDrag()
    {
        return false;
    }

    public bool CanClick()
    {
        return false;
    }

    public bool CanZoom()
    {
        return true;
    }

    public bool CanWait()
    {
        input.SetState(input.WaitState);
        return true;
    }
}