using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Range(0f,0.1f)]    public float speed;
    
    public enum ControlType
    {
        鍵盤 = 0, 手機陀羅儀 = 1, 滑鼠 = 2, 手機搖桿 = 3
    }
    [Header("選擇操控的方式")]
    public ControlType control;

    [Header("手機搖桿物件")]
    public GameObject JoystickObject;
    // 判斷是否有使用手機搖桿
    bool UseJoystick;
    // 判斷滑鼠是否點擊玩家物件
    bool MouseClick;

    [Header("玩家血量")]
    public float PlayerHp = 100;
    // 程式中計算玩家的血量數值
    float ScriptHp;
    [Header("玩家血條")]
    public Image HpBar;

    [Header("加分")]
    public int AddScore = 10;
    int Score;
    public Text ScoreText;

    // 儲存分數的欄位
    string SaveScore = "SaveScore";

    private void Start()
    {
        // 程式中的血量 = 屬性面板中調整的玩家血量數值
        ScriptHp = PlayerHp;
    }

    // 敵機子彈打到玩家，玩家進行扣血
    public void Damage(float hurt)
    {
        // 玩家血量遞減
        ScriptHp -= hurt;
        // 玩家血條的數值 = 程式中血量 / 自己設定的血量數值
        HpBar.fillAmount = ScriptHp / PlayerHp;
        // 限制玩家血量
        ScriptHp = Mathf.Clamp(ScriptHp, 0, PlayerHp);
        // 如果玩家血量 <= 0
        if (ScriptHp <= 0)
        {
            PlayerPrefs.SetFloat(SaveScore, Score);
            // 跳到遊戲結束畫面
            Application.LoadLevel("GameOver");
        }
    }

    // 得分
    public void GetScore()
    {
        Score += AddScore;
        ScoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        #region 註解
        // Input.GetKeyUp/Down(按下且放開/按下) -> 只執行一次
        // Input.GetKey -> 持續執行
        /*if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - 0.05f, transform.position.y);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x + 0.05f, transform.position.y);
        }*/

        // Input.GaetAxis("Horizontal") 沒有按按鍵的時候回傳值為0
        // Input.GaetAxis("Horizontal") 按"A"或左鍵的時候回傳值為-1
        // Input.GaetAxis("Horizontal") 按"D"或右鍵的時候回傳值為1
        // Input.GaetAxis("vertical") 沒有按按鍵的時候回傳值為0
        // Input.GaetAxis("vertical") 按"W"或上鍵的時候回傳值為1
        // Input.GaetAxis("vertical") 按"S"或下鍵的時候回傳值為-1
        #endregion

        #region 鍵盤控制
        // #if UNITY_STANDALONE
        // PC
        if ((int)control == 0)
        {
            transform.Translate(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"), 0);
        }
        // #endif
        #endregion

        #region 手機陀羅儀控制
        // #if UNITY_ANDROID
        // 手機陀螺儀
        if ((int)control == 1)
        {
            transform.Translate(speed * Input.acceleration.x, speed * Input.acceleration.y, 0);
        }
        // #endif
        #endregion

        #region 滑鼠控制
        #region 滑鼠說明
        // 滑鼠左鍵 ID = 0  右鍵 ID = 1  中間滾輪 ID = 2
        // if(Input.GetMouseButtonDown(0))  如果按下滑鼠左鍵，if 條件裡面的程式只會執行一次
        // if(Input.GetMouseButton(1))      如果按下滑鼠右鍵，if 條件裡面的程式持續執行，直到放開右鍵才停止
        // if(Input.GetMouseButtonUp(2))    如果按下滑鼠中鍵且放開，if 條件裡面的程式只會執行一次
        #endregion
        if ((int)control == 2)
        {
            if(Input.GetMouseButton(0) && MouseClick)
            {
                // Input.mousePosition 抓取滑鼠座標位置
                // Debug.Log(Input.mousePosition);
                // 記錄轉換後的座標位置
                Vector3 Point;
                // Camera.main 透過遊戲主攝影機 (Tag 要叫 MainCamera)
                // ScreenToWorldPoint 將螢幕的座標轉換成在遊戲編輯器內的三維座標數值
                Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Debug.Log(Point);
                // transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
                transform.position = new Vector3(Point.x, Point.y, transform.position.z);
                // 鼠標隱藏
                Cursor.visible = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                // 鼠標顯示
                Cursor.visible = true;
            }
        }
        #endregion

        #region 手機搖桿控制
        if ((int)control == 3)
        {
            JoystickObject.SetActive(true);
        }
        else
        {
            JoystickObject.SetActive(false);
        }
        #endregion

        #region 註解
        /*if (transform.position.x >= 2.2)
        {
            transform.position = new Vector2(2.3f, transform.position.y);
        }
        if(transform.position.x <= -2.3)
        {
            transform.position = new Vector2(2.3f, transform.position.y);
        }*/
        #endregion
        // (Mathf.Clamp(限制的值, 最小值, 最大值)
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.2f, 2.2f),
                                         Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
    #region 手機搖桿控制
    // 手指剛接觸搖桿
    public void UsingJoystick()
    {
        UseJoystick = true;
    }
    // 手指離開搖桿
    public void UnUsingJoystick()
    {
        UseJoystick = false;
    }
    // 手指正在拖動搖桿
    public void IsUsingJoystick(Vector3 pos)
    {
        if (UseJoystick)
        {
            transform.Translate(speed * pos.x, speed * pos.y, 0f);
        }
    }
    #endregion

    #region 滑鼠控制
    // 如果滑鼠點到玩家
    public void OnMouseDown()
    {
        MouseClick = true;
    }
    // 如果滑鼠沒有點到玩家
    public void OnMouseUp()
    {
        MouseClick = false;
    }
    #endregion

}
