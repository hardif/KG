using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeCamera : MonoBehaviour
{
    public Camera titlecamera;
    public Camera setcamera;
    public Button setbtn;
    public Button canclebtn, okbtn;
    public GameObject titleUI;
    public GameObject setUI;
    public TextMeshProUGUI numText;

    // Start is called before the first frame update
    void Start()
    {
        numText.GetComponent<TextMeshProUGUI>().faceColor = Color.white;

        //titleUI.SetActive(false);
        setUI.SetActive(false);
        //titlecamera.enabled = true;
        //setbtn.onClick.AddListener(ChangeUI);
        //setbtn.onClick.AddListener(ShowFirstPersonView);
    }

    // Update is called once per frame
    void Update()
    {
        numText.faceColor = Color.white;
        //setbtn.onClick.AddListener(changeSet);
        //setbtn.onClick.AddListener(showSetCamera);
    }

    public void showSetCamera()
    {
        titlecamera.enabled = false;
        setcamera.enabled = true;
    }

    public void showTitleCamera()
    {
        titlecamera.enabled = true;
        setcamera.enabled = false;
    }
    public void changeSet()
    {
        setUI.SetActive(true);
        titleUI.SetActive(false);

    }
    public void changeTitle()
    {
        setUI.SetActive(false);
        titleUI.SetActive(true);
        numText.GetComponent<TextMeshProUGUI>().faceColor = Color.white;

    }
    public void changeTextColor()
    {
        numText.GetComponent<TextMeshProUGUI>().faceColor = Color.white;
        //numText.color = new Color32(255, 255, 255, 255);
    }


}
