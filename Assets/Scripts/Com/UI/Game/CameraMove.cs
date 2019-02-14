using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 镜头移动
/// </summary>
public class CameraMove : MonoBehaviour {
    private bool isMove;
    private Vector3 target;
	void Update () {
        MoveView();
        LimitMove();
    }
    /// <summary>
    /// 移动视图
    /// </summary>
    private void MoveView()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            isMove = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMove = false;
        }
        if(isMove)
        {
            Vector3 mypos = transform.position;
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Mouse X"), transform.position.y, transform.position.z + Input.GetAxis("Mouse Y"));
        }
    }
    /// <summary>
    /// 限制移动范围
    /// </summary>
    private void LimitMove()
    {
        if (transform.position.x > 58)
        {
            transform.position = new Vector3(58, transform.position.y, transform.position.z);
        }
        if (transform.position.x < 30)
        {
            transform.position = new Vector3(30, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 58)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 58);
        }
        if (transform.position.z < 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 20);
        }
    }
}
