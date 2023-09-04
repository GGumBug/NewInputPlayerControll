using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int _groundMask = 1 << (int)Layer.Ground;

    private void Start()
    {
        InputManager.Instance.Add(InputType.Move, new PlayerMove());
    }

    public void Move()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.CurScreenPos);
        bool raycastHit = Physics.Raycast(ray, out hit, 100.0f, _groundMask);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 10, Color.red, 1f);

        if (raycastHit)
        {
            Vector3 hitPos = hit.point;
            Vector3 destPos = hitPos + new Vector3(0, transform.position.y, 0);
            transform.position = destPos;
        }
    }
}
