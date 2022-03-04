using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllScoreManager : MonoBehaviour
{
    public static AllScoreManager InstanceAllScore;
    private void Awake()
    {
        if (InstanceAllScore != null)
        {
            Destroy(gameObject);
            return;
        }
        InstanceAllScore = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NewBackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NewSettingButton()
    {
        SceneManager.LoadScene(3);
    }

    public void NewPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void DeleteButton()
    {

    }
}
