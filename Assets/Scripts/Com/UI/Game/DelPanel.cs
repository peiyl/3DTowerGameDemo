using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 只有删除按钮的面板
/// </summary>
public class DelPanel : MonoBehaviour {
    public Button DelBtn;
	void Start () {
        DelBtn.onClick.AddListener(() =>
        {
            TowerManager.Instance.theTower.SellTurret();
            TowerManager.Instance.DelPanel.SetActive(false);
        });
    }
}
