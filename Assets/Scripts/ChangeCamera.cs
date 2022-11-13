using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeCamera : MonoBehaviour
{
    public Camera titlecamera;
    public Camera setcamera;
    public Button setbtn;
    public Button canclebtn, okbtn;
    public GameObject titleUI;
    public GameObject setUI;
    public TextMesh asd;
    // Start is called before the first frame update
    void Start()
    {
        //titleUI.SetActive(false);
        setUI.SetActive(false);
        //setbtn.onClick.AddListener(ChangeUI);
        //setbtn.onClick.AddListener(ShowFirstPersonView);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
