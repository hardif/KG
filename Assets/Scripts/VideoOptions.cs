using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoOptions : MonoBehaviour
{
    List<Resolution> resolutions = new List<Resolution>();
    public TMP_Dropdown resolutionDropdown;
    public bool fullscreen;

    private void Start()
    {
        fullscreen = true;
    }
    void InitUI()
    {
        //resolutionDropdown = this.GetComponent<TMP_Dropdown>();
        /*
        resolutionDropdown.ClearOptions();
        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData options = new TMP_Dropdown.OptionData();
            options.text = item.width + "x" + item.height + "" + item.refreshRate + "hz";
            //resolutionDropdown.AddOptions(options);
            //resolutionDropdown.opt
            resolutionDropdown.options.Add(options);
        }
        resolutionDropdown.RefreshShownValue();
        */
    }
    public void changeWindow()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullscreen = !fullscreen;
    }
    
    public void changeRes()
    {
        switch (resolutionDropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, fullscreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, fullscreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, fullscreen);
                break;
            case 3:
                Screen.SetResolution(800, 600, fullscreen);
                break;

        }
    }
}
