using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioClass : MonoBehaviour
{
   private AudioManager _audioManager;

   private void Start()
   {
      _audioManager = AudioManager.Instance;
      _audioManager.Play ("MainTheme");
   }
}
