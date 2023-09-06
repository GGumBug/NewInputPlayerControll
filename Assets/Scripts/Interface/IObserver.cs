using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void Update();
}

public class PlayerMove : IObserver
{
    public void Update()
    {
        PlayerManager.Instance.PlayerCont.ShotMoveRay();
    }
}

public class CameraAxis : IObserver
{
    public void Update()
    {
        
    }
}
