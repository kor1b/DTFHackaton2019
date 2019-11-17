using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScaryThings : MonoBehaviour
{
    [SerializeField] private Transform dreamer = null; 
    [SerializeField] private AudioSource _audio;
    private float _rangeRadius;

    [SerializeField] private AudioClip[] noises;
    [SerializeField] private float maxDamage = 40f;
    [SerializeField] private AnimationCurve powerOfDamage = null;
    [SerializeField] private float displayTime = 5f;

    private Stress _stressInstance;
    
    private void Awake()
    {
        _stressInstance = Stress.Instance;
        
        _audio = GetComponent<AudioSource>();
        _rangeRadius = GetComponent<BoxCollider2D>().size.x / 2;
        noises = new AudioClip[1];
    }

    public void Scare()
    {
        float distanceToDreamer = Vector2.Distance(transform.position, dreamer.position);
        if (!CanScare(distanceToDreamer))
            return;

<<<<<<< HEAD:Helpmare/Assets/Scripts/ScaryThings.cs
        Debug.Log("StressUp by " + maxDamage * powerOfDamage.Evaluate(1 - (distanceToDreamer / rangeRadius)) + "Evaluated: " + powerOfDamage.Evaluate(1 - (distanceToDreamer / rangeRadius)));
        Stress.Instance.StressUp(maxDamage * powerOfDamage.Evaluate(1 - (distanceToDreamer / rangeRadius)));
=======
        _stressInstance.StressUp(maxDamage * powerOfDamage.Evaluate(1 - (distanceToDreamer / _rangeRadius)));
>>>>>>> EnemyAI:Helpmare/Assets/Scripts/Abilities/ScaryThings.cs

        SelectAndPlayAudio();
        DisplayGraphycs();

        StartCoroutine("Hide");
    }

    private bool CanScare(float distance)
    {
        return distance <= _rangeRadius;
    }

    private void SelectAndPlayAudio()
    {
        _audio.Stop();
        _audio.clip = noises[Random.Range(0, noises.Length)];
        _audio.Play();
    }

    private void DisplayGraphycs()
    {
        //TO DO
    }

    public IEnumerator Hide()
    {
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}
