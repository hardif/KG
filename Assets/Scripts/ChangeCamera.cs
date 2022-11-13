using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeCamera : MonoBehaviour
{
    public Camera titlecamera;
    public Camera setcamera;
    public Button setbtn;
    public GameObject titleUI;
    public GameObject setUI;
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
        setbtn.onClick.AddListener(ChangeUI);
        setbtn.onClick.AddListener(ShowOverheadView);
    }

    public void ShowOverheadView()
    {
        titlecamera.enabled = false;
        setcamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        titlecamera.enabled = true;
        setcamera.enabled = false;
    }
    public void ChangeUI()
    {
        setUI.SetActive(true);
        titleUI.SetActive(false);

    }
}
