using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 目标点触发事件脚本
/// </summary>
public class DestinationPoint : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Arrive();
        }
    }
}
