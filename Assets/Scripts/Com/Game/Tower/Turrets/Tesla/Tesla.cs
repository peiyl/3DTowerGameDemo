using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 减速塔
/// </summary>
public class Tesla : Turret
{
    /// <summary>
    /// 保持时间
    /// </summary>
    public float reduceSpeed;
    /// <summary>
    /// 速度减少百分比
    /// </summary>
    [Range(0,1)]
    public float speedPer;
    

    public override void Update()
    {
        base.Update();
    }
    public override void Attack()
    {
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<Enemy>().ReduceSpeed(speedPer, reduceSpeed);
        }
    }
}
