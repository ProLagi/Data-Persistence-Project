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
    }



}
