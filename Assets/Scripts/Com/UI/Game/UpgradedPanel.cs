using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 升级塔防面板管理
/// </summary>
public class UpgradedPanel : MonoBehaviour {
    /// <summary>
    /// 升级按钮
    /// </summary>
    public Button UpgradedBtn;
    /// <summary>
    /// 删除按钮
    /// </summary>
    public Button DelBtn;
    public Text CoinText;
    private void Start()
    {
        UpgradedBtn.onClick.AddListener(() =>
        {
            TowerManager.Instance.theTower.UpgradedTurret();
            TowerManager.Instance.UpgradedPanel.SetActive(false);
        });
        DelBtn.onClick.AddListener(() =>
        {
            TowerManager.Instance.theTower.SellTurret();
            TowerManager.Instance.UpgradedPanel.SetActive(false);
        });
    }
    public void UpdateCoinText(string s)
    {
        CoinText.text = s;
    }
}
