using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 炮台数据管理类
/// </summary>
[System.Serializable]
public class TurretData
{
    /// <summary>
    /// 炮台文件名前缀
    /// </summary>
    public string turretPrefab;
    /// <summary>
    /// 价格数组
    /// </summary>
    public int[] price;
}