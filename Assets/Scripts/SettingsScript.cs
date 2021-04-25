using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingsScript : MonoBehaviour
{
   public void setFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
  
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
