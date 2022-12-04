using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gameover : MonoBehaviour
{
    public GameObject GameOverUI;
    public bool Isgameover;
    public Image image;
    AudioSource audioData;
    

    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadetime;
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
            OverSound.playsound();
            StartCoroutine(Fade());
            Isgameover = true;
        }
    }

    private IEnumerator Fade()
    {

        float currentTime = 0.0f;
        float percent = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadetime;

            Color color = image.color;
            color.a = Mathf.Lerp(0, 1, percent);
            image.color = color;

            yield return null;

        }
        EndLoading.LoadScene("GameTitle");
    }
}
