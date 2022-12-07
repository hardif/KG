using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverSound : MonoBehaviour
{
    static AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public static void playsound()
    {
        audioData.Play();
    }
}
