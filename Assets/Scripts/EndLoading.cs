using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndLoading : MonoBehaviour
{

    static string nextScene;
    [SerializeField]
    Image progressBar;
   
    // Start is called before the first frame update

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("scene0");
    }
    void Start()
    {
        
        StartCoroutine(Load());

    }

    // Update is called once per frame
    IEnumerator Load()
    {
        progressBar.fillAmount = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
        
    }

}
