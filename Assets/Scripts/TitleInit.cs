using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInit : MonoBehaviour
{
    static public bool Load;
    // Start is called before the first frame update

    void Start()
    {
        Load = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IsLoad()
    {
        Debug.Log("Load == true");
        Load = true;
    }
}
