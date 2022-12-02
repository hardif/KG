using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ManageData : MonoBehaviour
{
    static GameObject container;

    static ManageData instance;
    public static ManageData Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "ManageData";
                instance = container.AddComponent(typeof(ManageData)) as ManageData;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }
    // 게임 데이터 파일이름 설정
    string GameDataFileName = "GameData.json";
    //저장용 클래스 변수
    public DataSet data = new DataSet();

    //게임정보 불러오기
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<DataSet>(FromJsonData);
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

}
