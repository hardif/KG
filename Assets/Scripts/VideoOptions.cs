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
    //public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        InitUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(resolutionDropdown.value == 1)
        {
            changeWindow();
        }
          
    }
    void InitUI()
    {
        resolutionDropdown = this.GetComponent<TMP_Dropdown>();
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
    void changeWindow()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("123");
    }
}
