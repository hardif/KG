using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POPUPController : MonoBehaviour
{
    private GameObject[] poparr;
    private GameObject[] ghostarr;
    public GameObject JSB;
    public GameObject ADSN;
    public GameObject VG;


    public GameObject player;
    public GameObject VGpopup;
    public GameObject ADSNpopup;
    public GameObject JSBpopup;
    Transform playerTrs;
    float[,] PlayerAndGhostDist;
    int ghostnum;
    private bool lockenter;
    // Start is called before the first frame update
    void Start()
    {
        poparr = new GameObject[3];
        ghostarr = new GameObject[3];
        string ThisGhost;
        ThisGhost = this.gameObject.name;
        if (ThisGhost == "JangSanBum2")
        {
            ghostnum = 0;
        }
        if (ThisGhost == "VirginGhost2")
        {
            ghostnum = 1;
        }
        if (ThisGhost == "Auduksini2")
        {
            ghostnum = 2;
        }
        poparr[0] = JSBpopup;
        poparr[1] = VGpopup;
        poparr[2] = ADSNpopup;

        ghostarr[0] = JSB;
        ghostarr[1] = VG;
        ghostarr[2] = ADSN;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrs = player.GetComponent<Transform>();
        PlayerAndGhostDist = new float[3, 1];

        lockenter = true;
        //popup.SetActive(true);
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAndGhostDist[ghostnum, 0] = Mathf.Round(Mathf.Abs(Vector3.Distance(playerTrs.position, this.transform.position)));
        if(PlayerAndGhostDist[ghostnum,0] < 10 && lockenter)
        {
            onClickPopUp(ghostnum); 

        }
        if (Input.GetKeyUp(KeyCode.Return) && !lockenter)
        {
            poparr[ghostnum].SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void onClickPopUp(int ghostnum)
    {
        ghostarr[ghostnum].SetActive(true);
        poparr[ghostnum].SetActive(true);
        Time.timeScale = 0;
        lockenter = false;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;

        
    }
}
