using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 管理所有的塔防武器的脚本
/// </summary>
public class TowerManager : MonoBehaviour {
    public static TowerManager Instance;
    /// <summary>
    /// 炮台数据配置
    /// </summary>
    public TurretData[] turretDatas;


    /// <summary>
    /// 炮台建造UI
    /// </summary>
    public GameObject TowerSelectPanel;
    private RectTransform TowerSelectRect;
    /// <summary>
    /// 炮台升级UI
    /// </summary>
    public GameObject UpgradedPanel;
    private RectTransform UpgradedRect;
    /// <summary>
    /// 删除炮台
    /// </summary>
    public GameObject DelPanel;
    private RectTransform DelRect;
    /// <summary>
    /// 选中的塔
    /// </summary>
    [HideInInspector]
    public PlatformTD theTower;
    /// <summary>
	/// 获取塔的Layer
	/// </summary>
	private LayerMask towerBasemask;
    private Ray ray;
    private RaycastHit hit;

    public Text coinText;
    public Text lifeText;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }
    private void Start()
    {
        TowerSelectRect = TowerSelectPanel.GetComponent<RectTransform>();
        UpgradedRect = UpgradedPanel.GetComponent<RectTransform>();
        DelRect = DelPanel.GetComponent<RectTransform>();
        //TowerSelectPanel.SetActive(false);
        //UpgradedPanel.SetActive(false);
        towerBasemask = 1 << (LayerMask.NameToLayer("Tower"));
    }
    private void Update()
    {
        BuildingOfRay();
    }
    /// <summary>
    /// 通过射线检测选中调用UI
    /// </summary>
    private void BuildingOfRay()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            TowerSelectPanel.SetActive(false);
            UpgradedPanel.SetActive(false);
            DelPanel.SetActive(false);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,1024,towerBasemask.value) && hit.collider.tag == "Grid")
            {
                theTower = hit.transform.GetComponent<PlatformTD>();
                ShowBuildUI();
            }
        }
    }
    private void ShowBuildUI()
    {
        //判断是否有子物体
        if (theTower.level == 0)
        {
            TowerSelectPanel.SetActive(true);
            TowerSelectRect.position = Input.mousePosition;
        }
        else if (theTower.level == 3)
        {
            DelPanel.SetActive(true);
            DelRect.position = Input.mousePosition;
        }
        else
        {
            UpgradedPanel.SetActive(true);
            UpgradedRect.position = Input.mousePosition;
            UpgradedPanel.GetComponent<UpgradedPanel>().UpdateCoinText(theTower.GetComponent<PlatformTD>().myTurretData.price[theTower.GetComponent<PlatformTD>().level].ToString());
        }
    }
    /// <summary>
    /// 更新金币数量ui
    /// </summary>
    /// <param name="s">金币数</param>
    public void UpdateCoinText(string s)
    {
        coinText.text = "金币："+s;
    }
    /// <summary>
    /// 更新水晶生命值ui
    /// </summary>
    /// <param name="s">生命值</param>
    public void UpdateLifeText(string s)
    {
        lifeText.text = "生命值：" + s;
    }
}
