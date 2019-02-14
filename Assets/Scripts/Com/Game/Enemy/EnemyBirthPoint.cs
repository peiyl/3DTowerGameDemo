using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人生成孵化器
/// </summary>
public class EnemyBirthPoint : MonoBehaviour {
    public static EnemyBirthPoint Instance;
    //public Wave[] waves;
    /// <summary>
    /// 怪的波数
    /// </summary>
    public Waves[] Waves;
    /// <summary>
    /// 下一大波敌人波计时
    /// </summary>
    public float waveRate = 1;
    /// <summary>
    /// 敌人存活数量
    /// </summary>
    public static int countEnemyAlive = 0;
	void Start () {
        Instance = this;
        StartCoroutine(CreateEnemy());
	}
	
    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(waveRate);
        foreach(Waves waves in Waves)
        {
            foreach (Wave wave in waves.waves)
            {
                for (int i = 0; i < wave.count; i++)
                {
                    Instantiate(wave.enemyPrefab, transform.position, Quaternion.identity);
                    countEnemyAlive++;
                    if (i != wave.count - 1)
                        yield return new WaitForSeconds(wave.rate);
                }
                //检测怪物是否为0（否则不进行下一次生成）
                while (countEnemyAlive > 0)
                    yield return 0;
                if (wave != waves.waves[waves.waves.Length - 1])
                    yield return new WaitForSeconds(waves.rate);
            }
            if (waves != Waves[Waves.Length - 1])
                yield return new WaitForSeconds(waveRate);
        }
        while (countEnemyAlive > 0)
            yield return 0;
        UIManager.Instance.uIState = UIState.end;
        UIManager.Instance.UpdateEndText("你获得了胜利");
        Time.timeScale = 0;
    }
}
