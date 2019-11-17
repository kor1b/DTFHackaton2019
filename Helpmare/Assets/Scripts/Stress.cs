using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stress : MonoBehaviour
{
    public static Stress Instance;

    [SerializeField] private float minStressValue = 0;
    [SerializeField] private float maxStressValue = 100;

<<<<<<< HEAD
    private float _stressLevel;
=======
    [SerializeField] private Slider stressBar;

    [SerializeField]private float stressTime = 5f;
    private float stressTimer = 5f;

    [SerializeField] private float stressPassiveDecriase = 0.1f;
    [SerializeField] private float lerpSpeed = 1.5f; 

    public float stressLevel;
>>>>>>> PortalMechanics

    //clamp stress level btw "minStressValue" and "maxStressValue"
    public float StressLevel
    {
        get => _stressLevel;
        private set
        {
            if (_stressLevel < minStressValue)
                _stressLevel = minStressValue;
            else if (_stressLevel > maxStressValue)
                _stressLevel = maxStressValue;
            else
<<<<<<< HEAD
                _stressLevel = value;
=======
                stressLevel = value;

>>>>>>> PortalMechanics
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

    private void Start()
    {
        stressTimer = stressTime;
    }

    //private void Update()
    //{
    //    if (stressTimer >= 0)
    //    {
    //        stressTimer -= Time.deltaTime;
    //    }
    //    else
    //    {
    //        StressDown(stressPassiveDecriase);
    //    }
    //}

    /// <summary>
    /// Increase stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressUp (float amount)
    {
        StressLevel += amount;
        stressTimer = stressTime;
        ChangeStressBar(StressLevel);

    }

    /// <summary>
    /// decrease stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressDown (float amount)
    {
        StressLevel -= amount;
        ChangeStressBar(StressLevel);
    }

    IEnumerator IncreaseSlider(float amount)
    {
        while (stressBar.value <= amount - 0.5f)
        {
            stressBar.value = Mathf.MoveTowards(stressBar.value, amount, lerpSpeed * Time.deltaTime);
            yield return Time.deltaTime;
        }
        stressBar.value = amount;
        yield return null;
    }

    /// <summary>
    /// Change stressBar level
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeStressBar(float amount)
    {
            stressBar.value = amount;
    }
}