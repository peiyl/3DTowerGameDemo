using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 激光塔
/// </summary>
public class Gauss : Turret {
    /// <summary>
    /// 发射点
    /// </summary>
    public Transform AttackPoint;
    /// <summary>
    /// 射线预制体
    /// </summary>
    public GameObject LinePrefab;
    /// <summary>
    /// 射线伤害值
    /// </summary>
    public float attack;
    private GameObject line;
    private LineRenderer myLineRender;
    private Ray ray;
    private RaycastHit hit;
	private LayerMask mask;
    private float myRadius;
    public void Start()
    {
        mask = 1 << (LayerMask.NameToLayer("Enemy"));
        myRadius = GetComponent<SphereCollider>().radius;
        line = Instantiate(LinePrefab, AttackPoint.position, Quaternion.identity);
        myLineRender = line.GetComponent<LineRenderer>();
        line.transform.SetParent(AttackPoint);
        line.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        if (target == null || Quaternion.Angle(turret.transform.rotation, Quaternion.LookRotation(target.position + new Vector3(0, 0.5f, 0) - turret.transform.position)) > 10)
            line.SetActive(false);
    }
    public override void Attack()
    {
        ray = new Ray(AttackPoint.position, AttackPoint.forward);
        if (Physics.Raycast(ray, out hit, myRadius, mask.value) && hit.transform == target.transform)
        {
            ShowLine(AttackPoint.position, hit.point);
            Debug.DrawLine(AttackPoint.position, hit.point, Color.red);
            //更新伤害
            target.GetComponent<Enemy>().OnDamage(attack * Time.deltaTime);
        }
    }
    public void ShowLine(Vector3 startPos,Vector3 endPos)
    {
        line.SetActive(true);
        myLineRender.SetPositions(new Vector3[] { startPos, endPos });
    }
}
