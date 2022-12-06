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
    public void SavePcoord(float x, float y, float z)
    {
        data.Pcoord[0] = x;
        data.Pcoord[1] = y;
        data.Pcoord[2] = z;

    }
    public void Isitemactive(bool jsb1, bool jsb2, bool jsb3, bool jsb4, bool vg1, bool vg2, bool vg3, bool vg4, bool adsn1, bool adsn2, bool adsn3)
    {
        data.activeitems[0] = jsb1;
        data.activeitems[1] = jsb2;
        data.activeitems[2] = jsb3;
        data.activeitems[3] = jsb4;
        data.activeitems[4] = vg1;
        data.activeitems[5] = vg2;
        data.activeitems[6] = vg3;
        data.activeitems[7] = vg4;
        data.activeitems[8] = adsn1;
        data.activeitems[9] = adsn2;
        data.activeitems[10] = adsn3;

    }
    public void setghostclear(bool JSB, bool VG, bool ADSN)
    {
        data.ghost[0] = JSB;
        data.ghost[1] = VG;
        data.ghost[2] = ADSN;
    }
    public void setGhostcoord(Vector3 JSB, Vector3 VG, Vector3 ADSN)
    {
        data.ghostcoord[0, 0] = JSB.x;
        data.ghostcoord[0, 1] = JSB.y;
        data.ghostcoord[0, 2] = JSB.z;
        data.ghostcoord[1, 0] = VG.x;
        data.ghostcoord[1, 1] = VG.y;
        data.ghostcoord[1, 2] = VG.z;
        data.ghostcoord[2, 0] = ADSN.x;
        data.ghostcoord[2, 1] = ADSN.y;
        data.ghostcoord[2, 2] = ADSN.z;
    }
    public void IsUIItemsactive(bool flash, bool earplug, bool ring, bool sunglass)
    {
        data.UIItems[0] = flash;
        data.UIItems[1] = earplug;
        data.UIItems[2] = ring;
        data.UIItems[3] = sunglass;
    }

    public void setghostactive(bool JSBact, bool VGact, bool ADSNact)
    {
        data.ghostactive[0] = JSBact;
        data.ghostactive[1] = VGact;
        data.ghostactive[1] = ADSNact;
    }

    public float[] GetPcoord()
    {

        return data.Pcoord;

    }
    public bool[] GetUIitemactive()
    {
        return data.UIItems;
    }
    public bool[] GetFieldItemactive()
    {   
        return data.activeitems;
    }
    public float[,] GetGhostCoord()
    {
        return data.ghostcoord;
    }
    public bool[] GetGhostClear()
    {
        return data.ghost;
    }
    public bool[] GetGhostactive()
    {
        return data.ghostactive;
    }

}
