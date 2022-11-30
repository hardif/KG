using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolume : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public void ToggleAudioVolume1()
    {
        if (toggle.isOn) AudioListener.volume = 1;
        else AudioListener.volume = 0;
    }
    public void ToggleAudioVolume2()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
