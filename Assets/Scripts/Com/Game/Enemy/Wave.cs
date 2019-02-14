using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 保存每一小波敌人生成需要的属性
/// </summary>
[System.Serializable]
public class Wave{
    /// <summary>
    /// 敌人预制体
    /// </summary>
    public GameObject enemyPrefab;
    /// <summary>
    /// 生成个数
    /// </summary>
    public int count;
    /// <summary>
    /// 怪物之间时间间隔
    /// </summary>
    public float rate;
}
/// <summary>
/// 保存每一大波敌人生成需要的属性
/// </summary>
[System.Serializable]
public class Waves {
    /// <summary>
    /// 一大波敌人中的几波敌人数组
    /// </summary>
    public Wave[] waves;
    /// <summary>
    /// 小波怪物之间时间间隔
    /// </summary>
    public float rate;
}

