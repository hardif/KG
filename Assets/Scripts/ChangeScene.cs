using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ChangeScene : MonoBehaviour
{
    float timer;
    public int timestart = 0;
    public Button startbtn;
    public Image image;
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadetime;

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        startbtn.onClick.AddListener(changeScene);
    }

    // Update is called once per frame
    void Update()
    {
        if(startbtn.gameObject.name == "loadbtn" && timestart == 1)
        {
            string GameDataFileName = "GameData.json";
            string filePath = Application.persistentDataPath + "/" + GameDataFileName;
            if (File.Exists(filePath))
            {
                timer += Time.deltaTime;
                timestart = 0;
                StartCoroutine(Fade());
            }
        }
        else if (timestart == 1){
            timer += Time.deltaTime;
            timestart = 0;
            StartCoroutine(Fade());
        }
    }
    void changeScene()
    {
        timestart = 1;
    }
    private IEnumerator Fade()
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
        while (percent <1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadetime;

            Color color = image.color;
            color.a = Mathf.Lerp(0, 1, percent);
            image.color = color;

            yield return null;

        }
        EndLoading.LoadScene("Scene_A");
    }
}
