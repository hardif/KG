using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject GameOverUI;
    public bool Isgameover;
    // Start is called before the first frame update
    void Start()
    {
        Isgameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            GameOverUI.SetActive(true);
            Isgameover = true;
            Time.timeScale = 0;
        }
    }
}
