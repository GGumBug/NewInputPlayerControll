using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public PlayerController PlayerCont { get; set; }

    public async void CreatePlayer()
    {
        GameObject go = await AddressableManager.Instance.Instantiate("Player");
        PlayerCont = go.GetComponent<PlayerController>();
    }
}
