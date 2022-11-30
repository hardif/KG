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
    // ���� ������ �����̸� ����
    string GameDataFileName = "GameData.json";
    //����� Ŭ���� ����
    public Data data = new Data();

    //�������� �ҷ�����
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            print("�ҷ����� �Ϸ�");
        }
    }

    // ���ӵ����� ����
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);

        print("���� �Ϸ�");
        

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
