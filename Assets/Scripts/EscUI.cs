
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EscUI : MonoBehaviour
{
    public GameObject SetUI;
    public GameObject ESCUI;
    public GameObject Player;
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
        ManageData.Instance.LoadGameData();
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
                Player.SetActive(false);
                gamestop++;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (Input.GetKeyUp(KeyCode.Escape) && ESCUI.activeSelf)
            {
                Player.SetActive(true);
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
        
        ManageData.Instance.SaveGameData();
    }
    public void OnClickLoad()
    {

    }
    public void OnClickMainMenu()
    {
        Debug.Log("타이틀로 이동");
        EndLoading.LoadScene("GameTitle");
    }

}
