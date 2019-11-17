<<<<<<< HEAD
﻿using UnityEngine;
=======
﻿using System;
using UnityEngine;
>>>>>>> EnemyAI
using UnityEngine.UI;

public class Stress : MonoBehaviour
{
    public static Stress Instance;

    [Header("Normal Stress")]
    [SerializeField] private float minNormalStressValue = 0;
   // [SerializeField] private float maxStressValue = 100;
    [SerializeField] private float normalStressSpeedDown = 15;

    [Header("Optimal Stress")]
    [SerializeField] private float minOptimalStressValue = 70;
 //   [SerializeField] private float maxOptimalStressValue = 89;
    [SerializeField] private float optimalStressSpeedDown = 10;

    [Header("Critical Stress")]
    [SerializeField] private float minCriticalStressValue = 90;            //stress level when dreamer dies
    [SerializeField] private float maxCriticalStressValue = 100;
    [SerializeField] private float criticalStressSpeedDown = 5;
    
    [Space]

    [SerializeField] private DreamerCharacter _dreamerCharacter;

    [SerializeField] private Slider stressSlider;

    private float _stressLevel;

<<<<<<< HEAD
    [SerializeField] private Slider stressSlider;
    
    //clamp stress level btw "minStressValue" and "maxStressValue"
=======
    //clamp stress level btw "minNormalStressValue" and "maxStressValue"
>>>>>>> EnemyAI
    public float StressLevel
    {
        get => _stressLevel;
        private set
        {
            if (_stressLevel < minNormalStressValue)
                _stressLevel = minNormalStressValue;
//            else if (_stressLevel > maxStressValue)
//                _stressLevel = maxStressValue;
            else
                _stressLevel = value;
        }
    }

#region Singleton

    private void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
    }

#endregion

    private void Update()
    {
        StressDownByTime();
        stressSlider.value = StressLevel;
    }

    /// <summary>
    /// Decrease stress by stress levels
    /// </summary>
    private void StressDownByTime()
    {
        if (StressLevel > minNormalStressValue && StressLevel < minOptimalStressValue)
            StressLevel -= normalStressSpeedDown * Time.deltaTime;
        else if (StressLevel >= minOptimalStressValue && StressLevel < minCriticalStressValue)
            StressLevel -= optimalStressSpeedDown * Time.deltaTime;
        else if (StressLevel >= minCriticalStressValue && StressLevel <= maxCriticalStressValue)
            StressLevel -= criticalStressSpeedDown * Time.deltaTime;
    }

    /// <summary>
    /// Increase stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressUp (float amount)
    {
        StressLevel += amount;
<<<<<<< HEAD
        stressSlider.value = StressLevel;
=======

        //if stress is bigger than critical - DIE
        if (StressLevel >= maxCriticalStressValue)
            _dreamerCharacter.Die();
>>>>>>> EnemyAI
    }

//    /// <summary>
//    /// decrease stress level
//    /// </summary>
//    /// <param name="amount"></param>
//    public void StressDown (float amount)
//    {
//        StressLevel -= amount;
//    }

    public bool IsOptimalStress()
    {
        return (StressLevel >= minOptimalStressValue && StressLevel < minCriticalStressValue);
    }

    public bool IsCriticalStress()
    {
<<<<<<< HEAD
        StressLevel -= amount;
        stressSlider.value = StressLevel;
=======
        return StressLevel >= minCriticalStressValue;
>>>>>>> EnemyAI
    }
}