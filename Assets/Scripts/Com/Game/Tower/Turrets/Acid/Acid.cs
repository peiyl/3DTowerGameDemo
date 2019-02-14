using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 炮塔
/// </summary>
public class Acid : Turret
{
    /// <summary>
    /// 发射点
    /// </summary>
    public Transform AttackPoint;
    /// <summary>
    /// 子弹预制体
    /// </summary>
    public GameObject BulletPrefab;
    /// <summary>
    /// 子弹伤害值
    /// </summary>
    public int attack;
    /// <summary>
    /// 子弹飞行速度
    /// </summary>
    public int speed;
    public override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        GameObject go = Instantiate(BulletPrefab, AttackPoint.position, AttackPoint.rotation);
        go.transform.SetParent(AttackPoint);
        AcidBullet ab = go.AddComponent<AcidBullet>();
        ab.speed = this.speed;
        ab.attack = this.attack;
        ab.SetTarget(target);
    }
}
