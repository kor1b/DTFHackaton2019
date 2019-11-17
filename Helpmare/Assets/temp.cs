using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public GameObject sc;
    private bool sc_prev_flag = false;
    public bool sc_flag = false;
    
    void Update()
    {
        if (sc_flag != sc_prev_flag)
        {
            //sc.SetActive(!sc.activeInHierarchy);
            sc.GetComponent<ScaryNoise>().Scare();
            sc_prev_flag = sc_flag;
        }
    }
}
