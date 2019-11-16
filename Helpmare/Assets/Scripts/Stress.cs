using UnityEngine;

public class Stress : MonoBehaviour
{
    public static Stress Instance;

    [SerializeField] private float minStressValue = 0;
    [SerializeField] private float maxStressValue = 100;

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

    /// <summary>
    /// Increase stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressUp (float amount)
    {
        StressLevel += amount;
    }

    /// <summary>
    /// decrease stress level
    /// </summary>
    /// <param name="amount"></param>
    public void StressDown (float amount)
    {
        StressLevel -= amount;
    }
}