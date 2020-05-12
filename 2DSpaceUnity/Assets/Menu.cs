using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // teacher:
    bool ControlSound = false;
    // bool ControlSound = true;
    [Header("聲音的按鈕")]
    public Image SoundBtnImg;
    [Header("聲音開啟圖")]
    public Sprite SoundOnImg;
    [Header("聲音關閉圖")]
    public Sprite SoundOffImg;
    [Header("聲音拉霸")]
    public Slider SoundBar;
    [Header("下拉選單")]
    public Dropdown ScreenSizeDropdown;

    // PlayerPrefs 儲存/取值資料欄位的名稱
    string SaveAudioSlider = "SaveAudioSlider";
    string SaveDropdown = "SaveDropdown";

    // teacher:
    private void Start()
    {
        Control_Sound();
        ScreenSet();
        // SoundBar.value = SaveData.SaveAudioSlider;
        SoundBar.value = PlayerPrefs.GetFloat(SaveAudioSlider);
        ScreenSizeDropdown.value = PlayerPrefs.GetInt(SaveDropdown);
        AudioListener.volume = SoundBar.value;
    }

    private void Update()
    {
        // 觸發slider才會更改值，若放在Update裡會一直偵測
        //#region 聲音拉霸控制
        //AudioListener.volume = SoundBar.value;
        //if(AudioListener.volume == 0)
        //{
        //    SoundBtnImg.sprite = SoundOffImg;
        //}
        //else if(ControlSound == true)
        //{
        //    SoundBtnImg.sprite = SoundOnImg;
        //}
        //#endregion

        #region 解析度設定
        //if(ScreenSizeDropdown.value == 0)
        //{
        //    // 設定遊戲執行檔的解析度 Screen.SetResolution(寬度,高度,是否全螢幕)
        //    Screen.SetResolution(1080, 1920, false);
        //}
        //else if (ScreenSizeDropdown.value == 1)
        //{
        //    Screen.SetResolution(720, 1280, false);
        //}
        //else if (ScreenSizeDropdown.value == 2)
        //{
        //    Screen.SetResolution(480, 800, false);
        //}
        /*SaveData.SaveDropdown = ScreenSizeDropdown.value;
        switch (ScreenSizeDropdown.value)
        {
            case 0:
                Screen.SetResolution(1080, 1920, false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(480, 800, false);
                break;
        }*/
        #endregion
    }

    #region 下一關
    public void NextScene()
    {
        // Application.LoadLevel(ID);
        // Application.LoadLevel("場景名稱");
        // Application.loadedLevel -> 讀取當前關卡名稱
        // Application.LoadLevel(Application.loadedLevel);  重新遊戲

        // 儲存聲音 SoundBar.value 值
        // SaveData.SaveAudioSlider = SoundBar.value;
        // 儲存浮點數 Playerfebs.SetFloat(儲存欄位名稱,儲存浮點數);
        PlayerPrefs.SetFloat(SaveAudioSlider,SoundBar.value);
        PlayerPrefs.SetInt(SaveDropdown, ScreenSizeDropdown.value);
        Application.LoadLevel(2);
    }
    #endregion

    #region 遊戲關閉
    public void Quit()
    {
        // 輸出成遊戲執行檔才可以進行測試
        Application.Quit();
    }
    #endregion

    #region 控制聲音
    public void Control_Sound()
    {
        // ! -> 相反的意思
        ControlSound = !ControlSound;
        if (ControlSound)
        {
            // 整體遊戲聲音都被開啟
            AudioListener.pause = false;
            // 聲音的按鈕圖換成 開聲音的圖片
            SoundBtnImg.sprite = SoundOnImg;
        }
        else
        {
            // 整體遊戲聲音都被關閉
            AudioListener.pause = true;
            // 聲音的按鈕圖換成 關聲音的圖片
            SoundBtnImg.sprite = SoundOffImg;
        }
    }
    #endregion

    #region 聲音拉霸控制
    // teacher      slider -> On Value Changed()
    public void ChangeAudioSlider()
    {
        if (SoundBar.value == 0)
        {
            ControlSound = true;
            Control_Sound();
        }
        else
        {
            ControlSound = false;
            Control_Sound();
        }
    }
    #endregion

    public void ScreenSet()
    {
        switch (ScreenSizeDropdown.value)
        {
            case 0:
                Screen.SetResolution(1080, 1920, false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(480, 800, false);
                break;
        }
    }
}
