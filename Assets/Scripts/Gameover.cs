using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if(activeJSB.activeSelf && activeVG.activeSelf && activeADSN.activeSelf)
        {
            //게임 엔딩 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            if(other.gameObject.name == "JangSanBum")
            {
                if(Earplug.activeSelf)
                {
                    activeJSB.SetActive(false);
                    JangSanBum.SetActive(false);


                }
                else
                {
                    gameover();
                }

            }
            if (other.gameObject.name == "VirginGhost")
            {
                if (Ring.activeSelf)
                {
                    activeVG.SetActive(false);
                    VirginGhost.SetActive(false);


                }
                else
                {
                    gameover();
                }

            }
            if (other.gameObject.name == "Auduksini")
            {
                if (Sunglass.activeSelf)
                {
                    activeADSN.SetActive(false);
                    Aduksini.SetActive(false);

                }
                else
                {
                    gameover();
                }

            }


            OverSound.playsound();

        }
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
