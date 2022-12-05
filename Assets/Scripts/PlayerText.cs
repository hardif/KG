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

    public GameObject window;

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
        if (TitleInit.Load == true)
        {
            window.SetActive(false);
            Time.timeScale = 1;
        }
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
                    ptext.text = "무슨 소리지?";
                    break;
                case 3:
                    ptext.text = "어질어질하네..@";
                    break;
                case 4:
                    ptext.text = "어디론가 빨려 들어가는 거 같다..";
                    break;
                case 5:
                    playercam.enabled = true;
                    Time.timeScale = 1;
                    txtwin.SetActive(false);

                    
                    break;
            }
            cnt++;
        }


    }
}
