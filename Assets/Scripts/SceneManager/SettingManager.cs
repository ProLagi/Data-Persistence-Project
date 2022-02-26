using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public void NewBackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NewSettingButton()
    {
        SceneManager.LoadScene(0);
    }
}
