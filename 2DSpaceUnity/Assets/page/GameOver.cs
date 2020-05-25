using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // 儲存分數的欄位
    string SaveScore = "SaveScore";
    string SaveHeightScore = "SaveHeightScore";
    string SaveLevelID = "SaveLevelID";
    
    [Header("分數")]
    public Text ScoreText;
    [Header("最高分數")]
    public Text HeightScoreText;

    [Header("下一關的按鈕")]
    public Button NextButton;

    private void Start()
    {
        Cursor.visible = true;
        
        ScoreText.text = "Score: " + PlayerPrefs.GetFloat(SaveScore);
        HeightScoreText.text = "Height Score: " + PlayerPrefs.GetFloat(SaveHeightScore + SaveLevelID);
        Debug.Log(PlayerPrefs.GetFloat(SaveHeightScore + SaveLevelID));

        // 如果目標分數 > 目前得分數 = 失敗
        if (PlayerPrefs.GetFloat(SaveHeightScore + SaveLevelID) > PlayerPrefs.GetFloat(SaveScore))
        {
            NextButton.interactable = false;
        }
        // 如果目標分數 <= 目前得分數 = 成功
        else
        {
            NextButton.interactable = true;
        }
    }

    // 回首頁
    public void Home()
    {
        Application.LoadLevel("Menu");
    }
    // 下一關
    public void NextGame()
    {
        if (PlayerPrefs.GetFloat(SaveLevelID) >= Level.OpenLevelID)
            Level.OpenLevelID++;
        Application.LoadLevel("Level");
    }
    // 重新遊戲
    public void ReGame()
    {
        Application.LoadLevel("Game");
    }
}
