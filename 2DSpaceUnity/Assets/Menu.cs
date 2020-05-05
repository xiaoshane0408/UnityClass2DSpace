using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool ControlSound = true;
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

    private void Update()
    {
        #region 聲音拉霸控制
        AudioListener.volume = SoundBar.value;
        if(AudioListener.volume == 0)
        {
            SoundBtnImg.sprite = SoundOffImg;
        }
        else
        {
            SoundBtnImg.sprite = SoundOnImg;
        }
        #endregion

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
        #endregion
    }

    #region 下一關
    public void NextScene()
    {
        // Application.LoadLevel(ID);
        // Application.LoadLevel("場景名稱");
        // Application.loadedLevel -> 讀取當前關卡名稱
        // Application.LoadLevel(Application.loadedLevel);  重新遊戲
        Application.LoadLevel(1);
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
}
