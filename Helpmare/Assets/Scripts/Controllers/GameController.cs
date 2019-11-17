using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; set; }

    public TextMeshProUGUI timerUI;
    //public Button playButton;
    //public Button exitButton;
    public GameObject mainMenuUI;
    public GameObject gameOverMenuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseMenu;

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
        //mainMenuUI.SetActive(true);
        //gameOverMenuUI.SetActive(false);
        Time.timeScale = 0;
        #endregion
    }

    /*void Start()
    {
        
        mainMenuUI.SetActive(true);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 0;
        //StartGame();
    }*/

    public void StartGame() //вызываем при запуске уровня. Держит все параметры в порядке:) 
    {
        startGame = true;

        Time.timeScale = 1;
        mainMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(false);
        gameUI.SetActive(true);
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
                GameOver();
                //EndGame();
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            System.Console.WriteLine("Space");
            PauseManager.Instance.PauseOn();
            StartCoroutine("ReloadScene", 1f);
            //StartGame();
        }
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Tab))
        {
            pauseMenu.SetActive(true);
            PauseManager.Instance.PauseOn();
        }
    }


    //вродь не используется
    public void EndGame()
    {
        startGame = false;
        //GameOver Window
        gameUI.SetActive(false);
        mainMenuUI.SetActive(false);
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f; //Можно перегрузить уровень и по пробелу, а можно и так(сразу)
    }

    public void GameOver()
    {
        gameUI.SetActive(false);
        gameOverMenuUI.SetActive(true);
        PauseManager.Instance.PauseOn();
    }

    IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
