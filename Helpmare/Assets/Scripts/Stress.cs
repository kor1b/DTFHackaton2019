using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stress : MonoBehaviour
{
    public static Stress Instance;

    [SerializeField] private float minStressValue = 0;
    [SerializeField] private float maxStressValue = 100;

    [SerializeField] private Slider stressBar;

    [SerializeField]private float stressTime = 5f;
    private float stressTimer = 5f;

    [SerializeField] private float stressPassiveDecriase = 0.1f;
    [SerializeField] private float lerpSpeed = 3f; 

    public float stressLevel;

    //clamp stress level btw "minStressValue" and "maxStressValue"
    public float StressLevel
    {
        get => stressLevel;
        private set
        {
            if (stressLevel < minStressValue)
                stressLevel = minStressValue;
            else if (stressLevel > maxStressValue)
                stressLevel = maxStressValue;
            else
                stressLevel = value;

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
        float animationTime = 0f;
        while (animationTime <= lerpSpeed)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / lerpSpeed;
            stressBar.value = Mathf.MoveTowards(stressBar.value, amount, lerpValue);
            yield return null;
        }
    }

    /// <summary>
    /// Change stressBar level
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeStressBar(float amount)
    {
        StartCoroutine(IncreaseSlider(amount));
    }
}