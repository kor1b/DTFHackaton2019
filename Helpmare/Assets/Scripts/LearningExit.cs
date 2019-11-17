using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningExit : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
        }
    }
}
