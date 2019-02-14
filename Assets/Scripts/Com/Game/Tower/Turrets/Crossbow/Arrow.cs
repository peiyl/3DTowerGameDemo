using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 箭
/// </summary>
public class Arrow : MonoBehaviour {
    /// <summary>
    /// 攻击力
    /// </summary>
    public float attack = 16;
    /// <summary>
    /// 子弹移动速度
    /// </summary>
    public float speed = 100f;
    private void Start()
    {
        StartCoroutine(Dead());
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    //private void Update()
    //{
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //}
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().OnDamage(attack);
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 三秒后自动销毁自身
    /// </summary>
    /// <returns></returns>
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
