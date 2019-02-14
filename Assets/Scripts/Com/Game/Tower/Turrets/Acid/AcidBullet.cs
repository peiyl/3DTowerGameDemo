using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 炮台的子弹的脚本
/// </summary>
public class AcidBullet : MonoBehaviour {
    /// <summary>
    /// 攻击力
    /// </summary>
    public float attack;
    /// <summary>
    /// 子弹移动速度
    /// </summary>
    public float speed;
    /// <summary>
    /// 跟随目标
    /// </summary>
    private Transform target;
    
    void Update () {
        FollowEnemy();
	}
    /// <summary>
    /// 子弹跟随怪物
    /// </summary>
	public void FollowEnemy()
    {
        if (target == null)
            Destroy(gameObject);
        else
        {
            transform.LookAt(target.position + new Vector3(0, 0.5f, 0));
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    /// <summary>
    /// 设置子弹的跟随对象
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().OnDamage(attack);
            Destroy(gameObject);
        }
    }
}
