using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScaryThings : MonoBehaviour
{
    [SerializeField]
    private Transform dreamer;
    [SerializeField]
    private AudioSource _audio;
    private float rangeRadius;

    [SerializeField]
    private AudioClip[] noises;
    [SerializeField]
    private float maxDamage = 40f;
    [SerializeField]
    private AnimationCurve powerOfDamage;
    [SerializeField]
    private float displayTime = 5f;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        rangeRadius = GetComponent<BoxCollider2D>().size.x / 2;
        noises = new AudioClip[1];
    }

    public void Scare()
    {
        float distanceToDreamer = Vector2.Distance(transform.position, dreamer.position);
        if (!CanScare(distanceToDreamer))
            return;

        //Debug.Log("StressUp by " + maxDamage * powerOfDamage.Evaluate(1 - (distanceToDreamer / rangeRadius)) + "Evaluated: " + powerOfDamage.Evaluate(1 - (distanceToDreamer / rangeRadius)));
        Stress.Instance.StressUp(maxDamage * powerOfDamage.Evaluate(1 - (distanceToDreamer / rangeRadius)));

        SelectAndPlayAudio();
        DisplayGraphycs();

        StartCoroutine("Hide");
    }

    private bool CanScare(float distance)
    {
        return distance <= rangeRadius;
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
