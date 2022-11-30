using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveData : MonoBehaviour
{
    static GameObject container;

    static SaveData instance;
    public static SaveData Instance
    {
        get
        {
            if(!Instance)
            {
                container = new GameObject();
                container.name = "SaveData";
                instance = container.AddComponent(typeof(SaveData)) as SaveData;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }
    // 게임 데이터 파일이름 설정
    string GameDataFileName = "GameData.json";
    //저장용 클래스 변수
    public Data data = new Data();

    //게임정보 불러오기
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            print("불러오기 완료");
        }
    }

    // 게임데이터 저장
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);

        print("저장 완료");
        

    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               
    }
}
