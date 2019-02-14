using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 跟随鼠标
/// </summary>
public class FollowMouse : MonoBehaviour {
    private float dirX;
    private float dirY;
    private Vector3 mousePos;
    public GameObject turret;
    private void FixedUpdate()
    {
        dirX = (Input.mousePosition.x - Screen.width / 2) / Screen.width / 2;
        dirY = (Input.mousePosition.y - Screen.height / 2) / Screen.height /2;
        mousePos = Quaternion.LookRotation(new Vector3(dirX, dirY, -0.2f)).eulerAngles;
        turret.transform.rotation = Quaternion.Euler(mousePos);
    }
}
