
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EscUI : MonoBehaviour
{
    public GameObject isJSBclear;
    public GameObject isVGaclear;
    public GameObject isADSNclear;


    AudioListener al;

    public TMP_Text PlayerUI;

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

    public GameObject Player;
    public GameObject SetUI;
    public GameObject ESCUI;
    public GameObject PlayerCam;
    public Camera InGameCamera;
    int gamestop = 0;
    public static bool lockesc;

    public TMP_Text savebtn;
    public TMP_Text loadbtn;
    public TMP_Text setbtn;
    public TMP_Text mainbtn;


    Vector3 jsbpos;
    Vector3 vgpos;
    Vector3 adsnpos;


    // Start is called before the first frame update

    void Start()
    {
        lockesc = false;
        gamestop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !lockesc)
        {
            
            if (gamestop == 0)
            {
                

                Vector3 pos = Player.gameObject.transform.position;
                if (JSB.activeSelf) { jsbpos = JSB.gameObject.transform.position; }
                if (VG.activeSelf) { vgpos = VG.gameObject.transform.position; }
                if (ADSN.activeSelf) { adsnpos = ADSN.gameObject.transform.position; }
                ManageData.Instance.IsUIItemsactive(flashimg.activeSelf, earplugimg.activeSelf, ringimg.activeSelf, sunglassimg.activeSelf);
                ManageData.Instance.setghostclear(!isJSBclear.activeSelf, !isVGaclear.activeSelf, !isADSNclear.activeSelf);
                ManageData.Instance.setghostactive(JSB.activeSelf, VG.activeSelf, ADSN.activeSelf);
                ManageData.Instance.Isitemactive(jsb1, jsb2, jsb3, jsb4, vg1, vg2, vg3, vg4, adsn1, adsn2, adsn3);
                ManageData.Instance.setGhostcoord(jsbpos, vgpos, adsnpos);
                ManageData.Instance.SavePcoord(pos.x, pos.y, pos.z);
                ManageData.Instance.SaveGameData();

                ESCUI.SetActive(true);
                savebtn.color = new Color32(255, 255, 255, 255);
                loadbtn.color = new Color32(255, 255, 255, 255);
                setbtn.color = new Color32(255, 255, 255, 255);
                mainbtn.color = new Color32(255, 255, 255, 255);
                PlayerCam.SetActive(false);
                PlayerUI.text = "";
                gamestop++;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                

            }
            else if (Input.GetKeyUp(KeyCode.Escape) && ESCUI.activeSelf)
            {
                PlayerCam.SetActive(true);
                ESCUI.SetActive(false);
                PlayerUI.text = "";
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
