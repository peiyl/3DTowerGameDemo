using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家游戏数据
/// </summary>
public class GameInfo : MonoBehaviour {
    private int coin = 200;
    /// <summary>
    /// 玩家持有金币
    /// </summary>
    public int Coin
    {
        get
        {
            return coin;
        }
    }
    private int crystalLife = 10;
    /// <summary>
    /// 水晶的生命
    /// </summary>
    public int CrystalLife
    {
        get
        {
            return crystalLife;
        }
    }
    public static GameInfo Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TowerManager.Instance.UpdateCoinText(coin.ToString());
        TowerManager.Instance.UpdateLifeText(crystalLife.ToString());
    }
    private void Update()
    {
        if(crystalLife <=0)
        {
            UIManager.Instance.uIState = UIState.end;
            UIManager.Instance.UpdateEndText("保卫失败");
            Time.timeScale = 0;
        }
    }
    /// <summary>
    /// 玩家获得金币
    /// </summary>
    /// <param name="coinNum">金币数</param>
    public void GetCoin(int coinNum)
    {
        this.coin += coinNum;
        TowerManager.Instance.UpdateCoinText(coin.ToString());
    }
    /// <summary>
    /// 玩家消费金币
    /// </summary>
    /// <param name="coinNum">金币数</param>
    /// <returns>交易是否成功</returns>
    public bool TakeCoin(int coinNum)
    {
        if (coin >=coinNum)
        {
            coin -= coinNum;
            TowerManager.Instance.UpdateCoinText(coin.ToString());
            return true;
        }
        return false;
    }
    /// <summary>
    /// 水晶生命减少
    /// </summary>
    /// <param name="num">减少数值</param>
    public void TakeCrystalLife(int num)
    {
        crystalLife -= num;
        TowerManager.Instance.UpdateLifeText(crystalLife.ToString());
    }
}
