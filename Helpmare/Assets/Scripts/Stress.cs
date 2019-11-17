using UnityEngine;
using UnityEngine.UI;

public class Stress : MonoBehaviour
{
    public static Stress Instance;

    [SerializeField] private float minStressValue = 0;
    [SerializeField] private float maxStressValue = 100;

    private float _stressLevel;

    [SerializeField] private Slider stressSlider;
    
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

    /// <summary>
    /// Increase stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressUp (float amount)
    {
        StressLevel += amount;
        stressSlider.value = StressLevel;
    }

    /// <summary>
    /// decrease stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressDown (float amount)
    {
        StressLevel -= amount;
        stressSlider.value = StressLevel;
    }
}