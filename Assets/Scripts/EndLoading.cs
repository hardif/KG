using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLoading : MonoBehaviour
{
    string nextScene;

    public void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadSceneProcess();
        LoadScene("Scene_A");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = true;

        yield return null;
    }
    
}
