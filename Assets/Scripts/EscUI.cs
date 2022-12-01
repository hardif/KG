using UnityEngine;

public class EscUI : MonoBehaviour
{
    public GameObject canvas;
    public GameObject SetUI;
    public GameObject ESCUI;
    int gamestop = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gamestop == 0)
            {
                canvas.SetActive(true);
                gamestop++;
                Time.timeScale = 0;
            }
            else
            {
                canvas.SetActive(false);
                gamestop--;
                Time.timeScale = 1;
            }
            
        }
        

    }

    public void OnClickSave()
    {

    }
    public void OnClickLoad()
    {

    }
    public void OnClickMainMenu()
    {

    }
    public void OnSettings()
    {
        SetUI.SetActive(true);
        ESCUI.SetActive(false);
    }
    public void OffSettings()
    {
        SetUI.SetActive(false);
        ESCUI.SetActive(true);
    }
}
