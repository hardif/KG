using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TitleInit : MonoBehaviour
{
    static public bool Load;
    // Start is called before the first frame update
    AudioSource audio;
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

        string GameDataFileName = "GameData.json";
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        if (File.Exists(filePath))
        {
            audio = this.GetComponent<AudioSource>();
            Load = true;
            Debug.Log("Load == true");
            audio.Play();
        }


    }
}
