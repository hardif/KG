using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        EndLoading.LoadScene("Scene_A");
    }
}
