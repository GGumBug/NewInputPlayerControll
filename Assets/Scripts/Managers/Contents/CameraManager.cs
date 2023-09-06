using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    CinemachineFreeLook palyerCam;

    public void CreatePlayerCam()
    {
        GameObject go = new GameObject("FreeLookCam");
        palyerCam = go.AddComponent<CinemachineFreeLook>();
        Transform target = PlayerManager.Instance.PlayerCont.transform;
        palyerCam.Follow = target;
        palyerCam.LookAt = target;
    }
}
