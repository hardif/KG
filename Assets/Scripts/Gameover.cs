using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Gameover : MonoBehaviour
{
    public GameObject GameOverUI;
    public Image image;
    AudioSource audioData;

    public GameObject activeJSB;
    public GameObject activeVG;
    public GameObject activeADSN;
    public GameObject Earplug;
    public GameObject Ring;
    public GameObject Sunglass;

    public GameObject JangSanBum;
    public GameObject VirginGhost;
    public GameObject Aduksini;

    public GameObject txtwin;
    public TMP_Text ptext;

    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadetime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.name == "JangSanBum")
            {
                if(Earplug.activeSelf)
                {

                    activeJSB.SetActive(false);
                    JangSanBum.SetActive(false);

                    if(activeJSB.activeSelf || activeVG || activeADSN)
                    {
                        Time.timeScale = 0;
                        txtwin.SetActive(true);

                        ptext.text = "없어진건가..? ";

                        if (Input.GetKeyDown(KeyCode.Return))
                        {
                            Time.timeScale = 1;
                            txtwin.SetActive(false);
                        }

                    }

                }
                else
                {
                    EscUI.lockesc = true;
                    gameover();
                }

            }
            if (other.gameObject.name == "VirginGhost")
            {
                if (Ring.activeSelf)
                {
                    activeVG.SetActive(false);
                    VirginGhost.SetActive(false);

                    if (activeJSB.activeSelf || activeVG || activeADSN)
                    {
                        Time.timeScale = 0;
                        txtwin.SetActive(true);

                        ptext.text = "없어진건가..? ";

                        if (Input.GetKeyDown(KeyCode.Return))
                        {
                            Time.timeScale = 1;
                            txtwin.SetActive(false);

                        }
                    }
                }
                else
                {
                    EscUI.lockesc = true;
                    gameover();
                }

            }
            if (other.gameObject.name == "Auduksini")
            {
                    if (Sunglass.activeSelf)
                    {
                        activeADSN.SetActive(false);
                        Aduksini.SetActive(false);

                        if (activeJSB.activeSelf || activeVG || activeADSN)
                        {
                            Time.timeScale = 0;
                            txtwin.SetActive(true);

                            ptext.text = "없어진건가..? ";

                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                Time.timeScale = 1;
                                txtwin.SetActive(false);

                            }
                        }
                    }
                    else
                    {
                        EscUI.lockesc = true;
                        gameover();
                    }




            
            }
            OverSound.playsound();
    }

    private IEnumerator Fade()
    {

        float currentTime = 0.0f;
        float percent = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadetime;

            Color color = image.color;
            color.a = Mathf.Lerp(0, 1, percent);
            image.color = color;

            yield return null;

        }
        EndLoading.LoadScene("GameTitle");
    }

    private void gameover()
    {
        OverSound.playsound();
        StartCoroutine(Fade());
    }

}
