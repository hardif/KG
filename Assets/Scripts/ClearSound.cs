using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSound : MonoBehaviour
{
    static AudioSource clearsound;
    // Start is called before the first frame update
    void Start()
    {
        clearsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void playsound()
    {
        clearsound.Play();
    }
}
