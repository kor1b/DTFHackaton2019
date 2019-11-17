using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DreamerCharacter : MonoBehaviour
{
    [SerializeField] private UnityEvent wakeUpEvent;
    [SerializeField] private UnityEvent deathEvent;

    private bool isDead = false;
    private bool hasPlayer = false;

    private Stress _stressInstance;

    private void Start()
    {
        _stressInstance = Stress.Instance;
    }

    private void Update()
    {
        //if player enter in the dreamer's circle and press Space
        if (hasPlayer && !isDead && _stressInstance.IsOptimalStress() && Input.GetKeyDown (KeyCode.Space))
        {
            wakeUpEvent?.Invoke();
            isDead = true;
        }
    }

    public void Die()
    {
        deathEvent.Invoke();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        //if player enter in the dreamer circle
        if (other.gameObject.CompareTag ("Player"))
        {
            hasPlayer = true;
        }
    }
}
