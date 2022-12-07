using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Scrollbar audioSlider;

    Gameover go;
    float volume;
    // Start is called before the first frame update

    void Start()
    {
        audioMixer.SetFloat("BGM", 0);
        audioMixer.SetFloat("Master", 0);
        audioMixer.SetFloat("SFX", 0);
    }
    // Update is called once per frame

    public void SFXControl()
    {
        volume = audioSlider.value;
        if (volume == 0f) audioMixer.SetFloat("SFX", -80);
        else audioMixer.SetFloat("SFX", volume*100 - 80);
    }
    public void MasterControl()
    {
        volume = audioSlider.value;
        if (volume == 0f) audioMixer.SetFloat("Master", -80);
        else audioMixer.SetFloat("Master", volume * 100 - 80);
    }
    public void BGMControl()
    {
        volume = audioSlider.value;
        if (volume == 0f) audioMixer.SetFloat("BGM", -80);
        else audioMixer.SetFloat("BGM", volume * 100 - 80);
    }
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

        
    
}
