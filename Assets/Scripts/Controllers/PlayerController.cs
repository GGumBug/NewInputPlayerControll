using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.Add(InputType.Move, new PlayerMove());
    }

    public void Move()
    {
        Vector3 destPos = InputManager.Instance.GetDestWorldPos(transform);
        transform.position = destPos;
    }
}
