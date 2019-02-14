using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 塔信息管理
/// </summary>
public class PlatformTD : MonoBehaviour
{
    [HideInInspector]
    public TurretData myTurretData = null;
    public int level = 0;
    /// <summary>
    /// 所持炮塔的价值
    /// </summary>
    private int trice;
    private GameObject go;
    /// <summary>
    /// 新建炮台
    /// </summary>
    /// <param name="turretData">炮台数据</param>
    public void CreateTurret(TurretData turretData)
    {
        myTurretData = turretData;
        if (GameInfo.Instance.TakeCoin(myTurretData.price[level]))
        {
            level++;
            go = Instantiate(Resources.Load<GameObject>("Prefab/Tower/" + myTurretData.turretPrefab + level), transform.position, Quaternion.identity);
        }
        else
            UIManager.Instance.UpdateHintText("您没有足够的金币"); ;
        //ui
    }
    /// <summary>
    /// 升级炮台
    /// </summary>
    public void UpgradedTurret()
    {
        if (GameInfo.Instance.TakeCoin(myTurretData.price[level]))
        {
            level++;
            //删除原来的炮台
            Destroy(go);
            //新建新的炮台
            go = Instantiate(Resources.Load<GameObject>("Prefab/Tower/" + myTurretData.turretPrefab + level), transform.position, Quaternion.identity);
        }
        else
            UIManager.Instance.UpdateHintText("您没有足够的金币");
        //ui
    }
    /// <summary>
    /// 出售塔防
    /// </summary>
    public void SellTurret()
    {
        //就算炮台当前价值
        for (int i = 0; i < level; i++)
        {
            trice += myTurretData.price[i];
        }
        //半价出售
        GameInfo.Instance.GetCoin(trice / 2);
        trice = 0;
        level = 0;
        Destroy(go);
    }
}
