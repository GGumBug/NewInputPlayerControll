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
        playerCam.AddComponent<InputProviderWhenDrag>();
        playerCam.AddComponent<ZoomInAndOut>();
        playerCam.UpdateInputAxisProvider();

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
        playerCam.m_YAxis.m_MaxSpeed = 1f;
        playerCam.m_XAxis.m_MaxSpeed = 100f;

        playerCam.Follow = target;
        playerCam.LookAt = target;
    }
}
