using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; set; }

    public TextMeshProUGUI timerUI;
    //public Button playButton;
    //public Button exitButton;
    public GameObject mainMenuUI;
    public GameObject gameOverMenuUI;

    [SerializeField]
    private float game_time = 300f;
    private float curTime = 0f;
    public bool startGame = false;
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
        Time.timeScale = 0;
        mainMenuUI.SetActive(true);
        gameOverMenuUI.SetActive(false);
        //StartGame();
    }

    public void StartGame() //вызываем при запуске уровня. Держит все параметры в порядке:) 
    {
        startGame = true;

        Time.timeScale = 1;
        mainMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        curTime = game_time;
    }

    void Update()
    {
        if (startGame)
        {
            if (curTime >= 0)
            {
                curTime -= Time.deltaTime;
                timerUI.text = ((int)curTime / 60).ToString("00") + ":" + ((int)curTime % 60).ToString("00");
            }
            else
            {
                EndGame();
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            System.Console.WriteLine("Space");
            StartGame();
        }
    }

    public void EndGame()
    {
        startGame = false;
        //GameOver Window
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        ReloadLevel(); //Можно перегрузить уровень и по пробелу, а можно и так(сразу)
    }

    private void ReloadLevel()
    {
        //ReloadinLevel(scene or prefab)
    }
}
