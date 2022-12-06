using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    float timer;
    int waitingTime;
    public AudioClip clip;
    AudioSource audiosource;
    public GameObject ClearJSB;
    public GameObject ClearVG;
    public GameObject ClearADSN;

    public GameObject ClearUI1;
    public GameObject ClearUI2;

    public GameObject GameoverUI;

    private void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
        timer = 0;
        waitingTime = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if(!ClearJSB.activeSelf && !ClearVG.activeSelf && !ClearADSN.activeSelf)
        {
            //Time.timeScale = 0;
            audiosource.clip = clip;
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }


            GameoverUI.SetActive(false);
            timer += Time.deltaTime;
            ClearUI1.SetActive(true);
            if(timer > waitingTime)
            {
                ClearUI1.SetActive(false);
                ClearUI2.SetActive(true);
            }
            if (timer > 2 * waitingTime) EndLoading.LoadScene("GameTitle");


        }
    }   
}
