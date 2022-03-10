using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager Instance;
    public string inputNameSave;
    public string bestNameSave;
    public string secondNameSave;
    public string thirdNameSave;
    public int scoreSave;
    public int bestScoreSave;
    public int secondScoreSave;
    public int thirdScoreSave;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadDataNamesAndScores();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestNameSeans;
        public string SecondNameSeans;
        public string ThirdNameSeans;
        public int BestScoreSeans;
        public int SecondScoreSeans;
        public int ThirdScoreSeans;

        public string inputNameSeans;
    }

    public void SaveDataNamesAndScores()
    {
        SaveData data = new SaveData();

        data.BestNameSeans = SaveDataManager.Instance.bestNameSave;
        data.BestScoreSeans = SaveDataManager.Instance.bestScoreSave;

        data.SecondNameSeans = SaveDataManager.Instance.secondNameSave;
        data.SecondScoreSeans = SaveDataManager.Instance.secondScoreSave;

        data.ThirdNameSeans = SaveDataManager.Instance.thirdNameSave;
        data.ThirdScoreSeans = SaveDataManager.Instance.thirdScoreSave;

        data.inputNameSeans = SaveDataManager.Instance.inputNameSave;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataNamesAndScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            SaveDataManager.Instance.bestNameSave = data.BestNameSeans;
            SaveDataManager.Instance.bestScoreSave = data.BestScoreSeans;

            SaveDataManager.Instance.secondNameSave = data.SecondNameSeans;
            SaveDataManager.Instance.secondScoreSave = data.SecondScoreSeans;

            SaveDataManager.Instance.thirdNameSave = data.ThirdNameSeans;
            SaveDataManager.Instance.thirdScoreSave = data.ThirdScoreSeans;

            SaveDataManager.Instance.inputNameSave = data.inputNameSeans;
        }
    }

}
