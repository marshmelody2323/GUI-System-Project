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

    List<int> widths = new List<int>() {568, 960, 1280, 1920};
    List<int> heights = new List<int>() {329, 540, 800, 1080};

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

}
