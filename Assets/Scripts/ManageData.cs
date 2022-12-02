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
    // ���� ������ �����̸� ����
    string GameDataFileName = "GameData.json";
    //����� Ŭ���� ����
    public DataSet data = new DataSet();

    //�������� �ҷ�����
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<DataSet>(FromJsonData);
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

}
