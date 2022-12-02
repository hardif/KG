
using UnityEngine;
using UnityEngine.UI;
public class EscUI : MonoBehaviour
{
    public GameObject canvas;
    public GameObject SetUI;
    public GameObject ESCUI;
    public Button OKbtn;
    public Camera InGameCamera;
    int gamestop = 0;
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
                canvas.SetActive(true);
                gamestop++;
                Time.timeScale = 0;
            }
            else if (Input.GetKeyUp(KeyCode.Escape) && canvas.activeSelf)
            {
                canvas.SetActive(false);
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

    }

}
