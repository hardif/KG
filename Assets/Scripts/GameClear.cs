using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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


    public GameObject Pwin;
    public TMP_Text ptext;

    public AudioClip audiozzz;
    public AudioClip audiohue;
    AudioSource audioSource;

    int cnt;
    bool isnext;
    
    private void Start()
    {
        cnt = 0;
        isnext = false;
        audiosource = this.GetComponent<AudioSource>();
        audioSource = this.GetComponent<AudioSource>();
        timer = 0;
        waitingTime = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if(!ClearJSB.activeSelf && !ClearVG.activeSelf && !ClearADSN.activeSelf)
        {
            EscUI.lockesc = true;
            Time.timeScale = 0;
            Pwin.SetActive(true);

            if(cnt == 0) ptext.text = "(Àá¿¡¼­ ±ú¾î³µ´Ù)";


            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (cnt)
                {
                    case 0:
                        audioSource.clip = audiozzz;
                        ptext.text = "..Çä...Çä..";
                        PlaySound("ZZZ");
                        break;
                    case 1:
                        ptext.text = "........";
                        break;
                    case 2:
                        ptext.text = "¿©±â´Â..?";
                        break;
                    case 3:
                        ptext.text = "ÈÞ... ²ÞÀÌ¾ú±¸³ª...";
                        PlaySound("Hue");
                        break;

                    case 4:
                        Time.timeScale = 1;
                        Pwin.SetActive(false);
                        isnext = true;
                        break;
                }
                cnt++;
            }



            if (isnext)
            {
                audiosource.clip = clip;
                if (!audiosource.isPlaying)
                {
                    audiosource.Play();
                }

                Time.timeScale = 1;

                GameoverUI.SetActive(false);
                timer += Time.deltaTime;
                ClearUI1.SetActive(true);
                if (timer > waitingTime)
                {
                    ClearUI1.SetActive(false);
                    ClearUI2.SetActive(true);
                }
                if (timer > 2 * waitingTime) EndLoading.LoadScene("GameTitle");
            }



        }
    }

    void PlaySound(string what)
    {
        switch (what)
        {
            case "ZZZ":
                audioSource.clip = audiozzz;
                break;
            case "Hue":
                audioSource.clip = audiohue;
                break;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
