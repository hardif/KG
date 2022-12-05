using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerText : MonoBehaviour
{
    public TMP_Text ptext;
    private int cnt;
    public GameObject txtwin;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch(cnt)
            {
                case 0:
                    ptext.text = "1";
                    break;
                    
                case 1:
                    ptext.text = "2";
                    break;
                case 2:
                    ptext.text = "3";
                    break;
                case 3:
                    ptext.text = "4";
                    break;
                case 4:
                    ptext.text = "";
                    txtwin.SetActive(false);
                    Time.timeScale = 1;
                    break;
            }
            cnt++;
        }

    }
}
