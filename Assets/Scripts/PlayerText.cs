using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerText : MonoBehaviour
{

    public GameObject isJSBclear;
    public GameObject isVGaclear;
    public GameObject isADSNclear;

    public GameObject JangSanBum;
    public GameObject VirginGhost;
    public GameObject Aduksini;

    public GameObject jsb1;
    public GameObject jsb2;
    public GameObject jsb3;
    public GameObject jsb4;
    public GameObject vg1;
    public GameObject vg2;
    public GameObject vg3;
    public GameObject vg4;
    public GameObject adsn1;
    public GameObject adsn2;
    public GameObject adsn3;


    public GameObject flashimg;
    public GameObject earplugimg;
    public GameObject ringimg;
    public GameObject sunglassimg;


    public GameObject Player;
    public Camera playercam;
    public TMP_Text ptext;
    private int cnt;
    public GameObject txtwin;

    public GameObject window;

    public AudioClip audiozzz;
    public AudioClip audiojang;
    AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(string what)
    {
        switch (what)
        {
            case "ZZZ":
                audioSource.clip = audiozzz;
                break;
            case "JANG":
                audioSource.clip = audiojang;
                break;
        }
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        playercam.enabled = false;
        cnt = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleInit.Load == true)
        {

            Debug.Log("데이터 로드 성공");
            ManageData.Instance.LoadGameData();

            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            //가져온 플레이어 위치 정보를 적용
            Physics.SyncTransforms();
            Player.transform.position = new Vector3(ManageData.Instance.GetPcoord()[0], ManageData.Instance.GetPcoord()[1], ManageData.Instance.GetPcoord()[2]);
            Physics.SyncTransforms();

            //아이템 UI 정보를 적용
            bool[] UIimg = new bool[4];
            UIimg = ManageData.Instance.GetUIitemactive();
            flashimg.SetActive(UIimg[0]);
            earplugimg.SetActive(UIimg[1]);
            ringimg.SetActive(UIimg[2]);
            sunglassimg.SetActive(UIimg[3]);


            //가져온 아이템 필드 정보를 적용

            bool[] fielditem = new bool[11];
            fielditem = ManageData.Instance.GetFieldItemactive();
            jsb1.SetActive(fielditem[0]);
            jsb2.SetActive(fielditem[1]);
            jsb3.SetActive(fielditem[2]);
            jsb4.SetActive(fielditem[3]);
            vg1.SetActive(fielditem[4]);
            vg2.SetActive(fielditem[5]);
            vg3.SetActive(fielditem[6]);
            vg4.SetActive(fielditem[7]);
            adsn1.SetActive(fielditem[8]);
            adsn2.SetActive(fielditem[9]);
            adsn3.SetActive(fielditem[10]);





            //가져온 귀신 좌표 정보를 적용
            float [,] gcoord = new float[3, 3];
            gcoord = ManageData.Instance.GetGhostCoord();
            JangSanBum.transform.position = new Vector3(gcoord[0, 0], gcoord[0, 1], gcoord[0, 2]);
            Physics.SyncTransforms();
            VirginGhost.transform.position = new Vector3(gcoord[1, 0], gcoord[1, 1], gcoord[1, 2]);
            Physics.SyncTransforms();
            Aduksini.transform.position = new Vector3(gcoord[2, 0], gcoord[2, 1], gcoord[2, 2]);
            Physics.SyncTransforms();


            //가져온 귀신 클리어 정보를 적용
            isJSBclear.SetActive(ManageData.Instance.GetGhostClear()[0]);
            isVGaclear.SetActive(ManageData.Instance.GetGhostClear()[1]);
            isADSNclear.SetActive(ManageData.Instance.GetGhostClear()[2]);

            playercam.enabled = true;
            TitleInit.Load = false;
            
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(cnt)
            {
                case 0:
                    ptext.text = "ZZzzzzzzz..";
                    PlaySound("ZZZ");
                    break;
                case 1:
                    ptext.text = "...?";
                    PlaySound("JANG");
                    break;
                case 2:
                    ptext.text = "무슨 소리지?";
                    break;
                case 3:
                    ptext.text = "어질어질하네..@";
                    break;
                case 4:
                    ptext.text = "어디론가 빨려 들어가는 거 같다..";
                    break;
                case 5:
                    playercam.enabled = true;
                    Time.timeScale = 1;
                    txtwin.SetActive(false);

                    
                    break;
            }
            cnt++;
        }


    }
}
