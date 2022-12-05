using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerText : MonoBehaviour
{
    public Camera playercam;
    public TMP_Text ptext;
    private int cnt;
    public GameObject txtwin;
    // Start is called before the first frame update
    void Start()
    {
        playercam.enabled = false;
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
                    ptext.text = "ZZzzzzzzz..";
                    break;
                    
                case 1:
                    ptext.text = "...?";
                    break;
                case 2:
                    ptext.text = "���� �Ҹ���?";
                    break;
                case 3:
                    ptext.text = "���������ϳ�..";
                    break;
                case 4:
                    ptext.text = "���а� �������°Ű���..";
                    playercam.enabled = true;
                    Time.timeScale = 1;
                    txtwin.SetActive(false);
                    break;
            }
            cnt++;
        }

    }
}
