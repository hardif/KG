using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject Flashimg;
    Light flash_light;
    Transform tr;
    KeyCode[] KeyCode_List;
    public static bool Flash = false;
    public AudioClip clip;
    
    // Start is called before the first frame update

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }

    private void Start()
    {
        flash_light.enabled = false;
    }

    void Awake()
    {
        flash_light = GetComponent<Light>();
        flash_light.innerSpotAngle = 120;
        flash_light.intensity = 2;
        //flash_light.
        tr = this.transform;

        Key_Depoly();
    }
    
    void Key_Depoly()
    {
        KeyCode_List = new KeyCode[10];
        KeyCode_List[0] = KeyCode.F;
        KeyCode_List[1] = KeyCode.Escape;
    }
    // Update is called once per frame
    void Update()
    {
        KeyCode result = User_Input();
        if (result == KeyCode_List[0])
        {
            if (Flashimg.activeSelf)
            {
                if (flash_light.enabled)
                    flash_light.enabled = false;
                else
                {
                    flash_light.enabled = true;
                    
                }
                SFXPlay("¼ÕÀüµî", clip);
            }
        }
    }
    KeyCode User_Input()
    {
        KeyCode result = KeyCode_List[1];
        
        for (int i = 0; i < KeyCode_List.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode_List[i]))
                result = KeyCode_List[i];
        }
        return result;
    }
    public static void getFlash()
    {
        Flash = true;
    }

    
}
