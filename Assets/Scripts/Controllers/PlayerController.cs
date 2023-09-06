using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isMove;
    float speed = 5f;
    int _groundMask = 1 << (int)Layer.Ground;
    Vector3 destPos;

    private void Start()
    {
        AddInput();
    }

    private void Update()
    {
        if (isMove)
        {
            Move(destPos);
        }
    }

    public void AddInput()
    {
        InputManager.Instance.Add(InputType.Move, new PlayerMove());
    }

    public void ShotMoveRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.CurScreenPos);
        bool raycastHit = Physics.Raycast(ray, out hit, 100.0f, _groundMask);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 10, Color.red, 1f);

        if (raycastHit)
        {
            Vector3 hitPos = hit.point;
            destPos = hitPos + new Vector3(0, transform.position.y, 0);
            isMove = true;
        }
    }

    void Move(Vector3 destPos)
    {
        Vector3 dir = destPos - transform.position;
        float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);

        if (dir.magnitude < 0.1f)
            isMove = false;

        transform.position += dir.normalized * moveDist;
    }
}
