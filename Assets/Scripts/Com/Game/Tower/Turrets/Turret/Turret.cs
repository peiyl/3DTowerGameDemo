using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 炮台基类
/// </summary>
public class Turret : MonoBehaviour {
    /// <summary>
    /// 进入触发器的怪物列表
    /// </summary>
    public List<GameObject> enemys = new List<GameObject>();
    /// <summary>
    /// 炮台
    /// </summary>
    public GameObject turret;
    private Quaternion rotate;
    /// <summary>
    /// 发射时间间隔
    /// </summary>
    public float spaceTime;
    /// <summary>
    /// 旋转的速度
    /// </summary>
    private float rotateSpeed = 10f;
    /// <summary>
    /// 间隔时间结束可以攻击
    /// </summary>
    private bool isAttack = true;
    /// <summary>
    /// 攻击目标
    /// </summary>
    protected Transform target;
    /// <summary>
    /// 被标记目标
    /// </summary>
    [HideInInspector]
    public Transform flagTarget;
    public virtual void Update()
    {
        UpdateEnemys();
        if (enemys.Count > 0)
        {
            target = enemys[0].transform;
            FollowEnemyAndAttack();
        }
        else
        {
            target = null;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        } 
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }
    /// <summary>
    /// 炮台攻击方法
    /// </summary>
    public virtual void Attack()
    {

    }
    /// <summary>
    /// 炮台AI（Update）
    /// </summary>
    public void FollowEnemyAndAttack()
    {
        if (turret != null)
        {
            //Vector3 length = target.GetComponent<MeshFilter>().mesh.bounds.size;
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(target.position + new Vector3(0, 0.5f, 0) - turret.transform.position), rotateSpeed * Time.deltaTime);
            //当夹角小于10开始进攻
            if (Quaternion.Angle(turret.transform.rotation, Quaternion.LookRotation(target.position + new Vector3(0, 0.5f, 0) - turret.transform.position)) <= 10)
                OnAttack();
        }
        else//如果没有炮台，就当前需求来看属于减速塔，直接进行攻击
        {
            OnAttack();
        }
    }
    /// <summary>
    /// 计时攻击（Update）
    /// </summary>
    public void OnAttack()
    {
        if (isAttack)
            StartCoroutine(StartAttack());
    }
    /// <summary>
    /// 移除列表中的空对象
    /// </summary>
    public void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                emptyIndex.Add(i);
            }
        }
        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i]-i);
        }
    }
    /// <summary>
    /// 设置炮台目标
    /// </summary>
    /// <param name="target">目标</param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    /// <summary>
    /// 攻击计时
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAttack()
    {
        isAttack = false;
        Attack();
        yield return new WaitForSeconds(spaceTime);
        isAttack = true;
    }
}
