using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraManager : Singleton<CameraManager>
{
    CinemachineFreeLook playerCam;

    public void CreatePlayerCam()
    {
        GameObject go = new GameObject("FreeLookCam");
        playerCam = go.AddComponent<CinemachineFreeLook>();
        var inputProvider = playerCam.AddComponent<InputProviderWhenDrag>();
        playerCam.UpdateInputAxisProvider();
        InputManager.Instance.Add(InputType.Zoom, new CameraZoom());

        SetPlayerCam();
    }

    void SetPlayerCam()
    {
        Transform target = PlayerManager.Instance.PlayerCont.transform;
        playerCam.m_BindingMode = CinemachineTransposer.BindingMode.WorldSpace;
        playerCam.m_Lens.FieldOfView = 50f;
        //Rig 별로 카메라 거리 셋팅
        playerCam.m_Orbits[0].m_Radius = 3;
        playerCam.m_Orbits[1].m_Radius = 5;
        playerCam.m_Orbits[2].m_Radius = 3;

        playerCam.m_YAxis.m_InvertInput = true;

        playerCam.Follow = target;
        playerCam.LookAt = target;
    }

    public void ZoomInAndOut(Vector2 value)
    {
        float yAxis = value.y;
        if (yAxis > 0)
        {
            playerCam.m_Orbits[0].m_Radius++;
            playerCam.m_Orbits[1].m_Radius++;
            playerCam.m_Orbits[2].m_Radius++;
        }
        else if (yAxis < 0)
        {
            playerCam.m_Orbits[0].m_Radius--;
            playerCam.m_Orbits[1].m_Radius--;
            playerCam.m_Orbits[2].m_Radius--;
        }
    }
}
