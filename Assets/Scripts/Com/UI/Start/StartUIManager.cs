using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartUIManager : MonoBehaviour {
    public Button PlayBtn;
    public Button ExitBtn;
    public Button SettingBtn;

    public GameObject Tow;
    public GameObject SettingBG;
    public GameObject PlayButton;
    public GameObject ExitButton;

    /// <summary>
    /// set是否显示
    /// </summary>
    private bool setIsShow =false;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start () {
        PlayBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Map");
        });
        ExitBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
        });
        SettingBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            if(setIsShow)
            {
                HideSetting();
                setIsShow = false;
            }
            else
            {
                ShowSetting();
                setIsShow = true;
            }
        });
	}
    private void ShowSetting()
    {
        SettingBG.SetActive(true);
        PlayButton.SetActive(false);
        ExitButton.SetActive(false);
        Tow.SetActive(false);
    }
    private void HideSetting()
    {
        SettingBG.SetActive(false);
        PlayButton.SetActive(true);
        ExitButton.SetActive(true);
        Tow.SetActive(true);
    }
}
