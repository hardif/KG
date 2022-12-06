
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EscUI : MonoBehaviour
{
    

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

    public GameObject JSB;
    public GameObject VG;
    public GameObject ADSN;

    public GameObject RealObj;
    public GameObject Player;
    public GameObject SetUI;
    public GameObject ESCUI;
    public GameObject PlayerCam;
    public Button OKbtn;
    public Camera InGameCamera;
    int gamestop = 0;

    public TMP_Text savebtn;
    public TMP_Text loadbtn;
    public TMP_Text setbtn;
    public TMP_Text mainbtn;



    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gamestop == 0)
            {
                ESCUI.SetActive(true);
                savebtn.color = new Color32(255, 255, 255, 255);
                loadbtn.color = new Color32(255, 255, 255, 255);
                setbtn.color = new Color32(255, 255, 255, 255);
                mainbtn.color = new Color32(255, 255, 255, 255);
                PlayerCam.SetActive(false);
                gamestop++;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                

            }
            else if (Input.GetKeyUp(KeyCode.Escape) && ESCUI.activeSelf)
            {
                PlayerCam.SetActive(true);
                ESCUI.SetActive(false);
                gamestop--;
                Time.timeScale = 1;
                InGameCamera.enabled = true;
            }
        }


    }
    public void OnSettings()
    {
        SetUI.SetActive(true);
        ESCUI.SetActive(false);
        InGameCamera.enabled = false;



    }
    public void OffSettings()
    {
        ESCUI.SetActive(true);
        SetUI.SetActive(false);
        
    }

    public void OnClickSave()   
    {
        Vector3 pos = Player.gameObject.transform.position;
        Vector3 jsbpos = JSB.gameObject.transform.position;
        Vector3 vgpos = VG.gameObject.transform.position;
        Vector3 adsnpos = ADSN.gameObject.transform.position;
        ManageData.Instance.Isghostactive(JSB.activeSelf, VG.activeSelf, ADSN.activeSelf);
        ManageData.Instance.Isitemactive(jsb1, jsb2, jsb3, jsb4, vg1, vg2, vg3, vg4, adsn1, adsn2, adsn3);
        ManageData.Instance.getghostcoord(jsbpos, vgpos, adsnpos);
        ManageData.Instance.SavePcoord(pos.x, pos.y, pos.z);
        ManageData.Instance.SaveGameData();
        Cursor.visible = true;
    }
    public void OnClickLoad()
    {

    }
    public void OnClickMainMenu()
    {
        gamestop--;
        PlayerCam.SetActive(true);
        InGameCamera.enabled = true;
        ESCUI.SetActive(false);
        Debug.Log("타이틀로 이동");
        EndLoading.LoadScene("GameTitle");
    }

}
