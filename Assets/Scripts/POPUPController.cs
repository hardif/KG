using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POPUPController : MonoBehaviour
{
    public GameObject popup;
    private bool lockenter;
    // Start is called before the first frame update
    void Start()
    {
        lockenter = true;
        popup.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) && lockenter)
        {
            onClickPopUp();
        }
    }
    public void onClickPopUp()
    {
        lockenter = false;
        Time.timeScale = 1;
        popup.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;
    }
}
