using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// UI管理
/// </summary>
public enum UIState
{
    gameing,
    end
}
public class UIManager : MonoBehaviour {
    public static UIManager Instance;
    public UIState uIState;
    public GameObject GameingPanel;
    public GameObject EndPanel;

    public Text EndText;
    public Button EndButton;

    //public Text HintText;
    public GameObject HintGB;
    public Transform HintPos;

    public Button BiginButton;
    public Button PauseButton;
    public Button SpeedUpButton;

    void Start () {
        Instance = this;
        uIState = UIState.gameing;
        EndButton.onClick.AddListener(() => { SceneManager.LoadScene("Start"); });
        BiginButton.onClick.AddListener(() => { Time.timeScale = 1; });
        PauseButton.onClick.AddListener(() => { Time.timeScale = 0; });
        SpeedUpButton.onClick.AddListener(()=> { Time.timeScale = 2; });
        StartCoroutine(GameBeginHint());
	}
	void Update () {
        UIStateFSM();
	}
    public void UIStateFSM()
    {
        switch(uIState)
        {
            case UIState.gameing:
                GameingPanel.SetActive(true);
                EndPanel.SetActive(false);
                break;
            case UIState.end:
                GameingPanel.SetActive(false);
                EndPanel.SetActive(true);
                break;
        }
    }
    public void UpdateEndText(string s)
    {
        EndText.text = s;
    }
    public void UpdateHintText(string s)
    {
        Hint hint = Instantiate(HintGB, HintPos).GetComponent<Hint>();
        hint.SetHintText(s);
    }
    IEnumerator GameBeginHint()
    {
        UpdateHintText("保护水晶！");
        yield return new WaitForSeconds(0.5f);
        UpdateHintText("安放炮台！！");
    }
}
