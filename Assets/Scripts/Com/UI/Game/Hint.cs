using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hint : MonoBehaviour {
    public Text text;
    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }
    /// <summary>
    /// 设置提示信息
    /// </summary>
    /// <param name="s">提示文本</param>
    public void SetHintText(string s)
    {
        text.text = s;
    }
}
