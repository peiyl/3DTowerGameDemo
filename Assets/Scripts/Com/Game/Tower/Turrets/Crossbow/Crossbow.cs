using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 箭塔
/// </summary>
public class Crossbow : Turret {
    /// <summary>
    /// 箭预制体
    /// </summary>
    public GameObject crossbowPrefab;
    /// <summary>
    /// 发射点数组
    /// </summary>
    public Transform[] AttackPoint;
    public override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        for (int i = 0; i < AttackPoint.Length; i++)
        {
            GameObject go = Instantiate(crossbowPrefab, AttackPoint[i].position, AttackPoint[i].rotation);
            go.transform.SetParent(AttackPoint[i]);
            Arrow arrow = go.AddComponent<Arrow>();
        }
    }
}
