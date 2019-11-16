using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; set; }

    public TextMeshProUGUI timerUI;

    [SerializeField]
    private float game_time = 300f;
    private float curTime = 0f;
    public bool startGame = true;
    //private float Time { get; set; }

    void Awake()
    {
        #region Singelton
        if (Instance == null)
        {
            Instance = this;
        }
        #endregion
    }

    void Start()
    {
        StartGame();
    }

    private void StartGame() //вызываем при запуске уровня. Держит все параметры в порядке:) 
    {
        Time.timeScale = 1;
        if (startGame)
            curTime = game_time;
        else
        {
            Time.timeScale = 0;            //Мало ли чё
            RestartGame();
        }
    }

    void Update()
    {
        if (startGame && curTime >= 0)
        {
            curTime -= Time.deltaTime;
            timerUI.text = ((int)curTime/60).ToString("00") + ":" + ((int)curTime%60).ToString("00");
        }
        else
        {
            EndGame();
        }
    }

    public void EndGame()                        
    {
        //GameOver Window

        startGame = false;
        RestartGame();
    }

    private void RestartGame()
    {

        //ReloadLevel
        Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame = true;
            StartGame();
        }
    }
}
