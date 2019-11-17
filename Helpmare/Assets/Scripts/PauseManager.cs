using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void PauseOn() //остановить время
    {
        Time.timeScale = 0;
    }

    public void PauseOff() //запустить время
    {
        Time.timeScale = 1;
    }
}