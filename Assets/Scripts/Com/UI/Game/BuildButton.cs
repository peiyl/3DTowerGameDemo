using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 建造塔防按钮脚本
/// </summary>
public class BuildButton : MonoBehaviour
{
    /// <summary>
    /// 塔防预制体数组下标
    /// </summary>
    public int num;
    /// <summary>
    /// 本按钮的信息
    /// </summary>
    private TurretData turretData;
    public Text CoinText;
    private void Start()
    {
        turretData = TowerManager.Instance.turretDatas[num];
        CoinText.text = turretData.price[0].ToString();
        gameObject.GetComponent<Button>().onClick.AddListener(() => 
        {
            TowerManager.Instance.theTower.CreateTurret(turretData);
            TowerManager.Instance.TowerSelectPanel.SetActive(false);
        });
    }
    
}
