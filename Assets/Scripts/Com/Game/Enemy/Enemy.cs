using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
/// <summary>
/// 小怪智能移动
/// </summary>
public class Enemy : MonoBehaviour {
    /// <summary>
    /// 怪的最大血量
    /// </summary>
    public float enemyMaxLife;
    /// <summary>
    /// 怪的血条
    /// </summary>
    public Slider lifeSlider;
    /// <summary>
    /// 怪的现有血量
    /// </summary>
    private float enemyLife;

    /// <summary>
    /// 怪的初始速度
    /// </summary>
    public float initSpeed;
    /// <summary>
    /// 减速时间
    /// </summary>
    private float reduceTime;
    /// <summary>
    /// 怪的当前速度
    /// </summary>
    //private float speed;
    /// <summary>
    /// 减速标记
    /// </summary>
    private bool reduceBuff = false;

    /// <summary>
    /// 对水晶伤害
    /// </summary>
    public int attack;
    /// <summary>
    /// 返回金币数值
    /// </summary>
    public int coin;

    /// <summary>
    /// 目标点
    /// </summary>
    private Transform DestinationPoint;
    private NavMeshAgent meshAgent;
    void Start () {
        meshAgent = this.GetComponent<NavMeshAgent>();
        DestinationPoint = GameObject.Find("DestinationPoint").transform;
        meshAgent.SetDestination(DestinationPoint.position);
        meshAgent.speed = this.initSpeed;
        //speed = initSpeed;
        enemyLife = enemyMaxLife;
	}
    private void Update()
    {
        if(enemyLife<=0)
        {
            Dead();
        }
    }
    
    /// <summary>
    /// 到达终点处理
    /// </summary>
    public void Arrive()
    {
        //生成特效
        GameInfo.Instance.TakeCrystalLife(attack);
        Destroy(gameObject);
        EnemyBirthPoint.countEnemyAlive--;
    }
    
    public void Dead()
    {
        //生成特效
        GameInfo.Instance.GetCoin(coin);
        Destroy(gameObject);
        EnemyBirthPoint.countEnemyAlive--;
    }
    /// <summary>
    /// 怪物受伤
    /// </summary>
    /// <param name="damage">伤害值</param>
    public void OnDamage(float damage)
    {
        enemyLife -= damage;
        lifeSlider.value = (float)enemyLife / enemyMaxLife;
    }
    /// <summary>
    /// 怪减速
    /// </summary>
    /// <param name="speedPer">减少的速度百分比</param>
    /// <param name="reduceTime">时效</param>
    public void ReduceSpeed(float speedPer, float reduceTime)
    {
        if (reduceBuff)
            return;
        this.reduceTime = reduceTime;
        StartCoroutine(ReduceSpeed(speedPer));
    }
    /// <summary>
    /// 减速buff计时
    /// </summary>
    /// <param name="speedPer">持续时间</param>
    /// <returns></returns>
    IEnumerator ReduceSpeed(float speedPer)
    {
        reduceBuff = true;
        meshAgent.speed = initSpeed * (1.0f-speedPer);
        if (meshAgent.speed <= 0)
        {
            meshAgent.speed = 0;
        }
        Debug.Log("我：" + gameObject.name + "被减速啦，我现在的速度是：" + meshAgent.speed);
        yield return new WaitForSeconds(reduceTime);
        meshAgent.speed = initSpeed;
        Debug.Log("我：" + gameObject.name + "速度恢复啦" + meshAgent.speed);
        reduceBuff = false;
    }
}
