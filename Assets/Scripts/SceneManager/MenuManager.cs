using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject nullEnterPanel;
    public GameObject settingButton;
    private bool isOpenDialog;

    private string inputName;

    private void Start()
    {
        isOpenDialog = false;
    }

    public void NewPlayScene()
    {
        if (!isOpenDialog)
        {
            if (inputName == null)
            {
                OpenDialog();
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void NewAllScoreScene()
    {
        if(!isOpenDialog)
        {
            SceneManager.LoadScene(2);
        }   
    }

    public void NewExitScene()
    {
        if (!isOpenDialog)
        {
            Application.Quit();
        }   
    }

    public void OpenDialog()
    {
        nullEnterPanel.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
        isOpenDialog = true;
    }

    public void CloseDialog()
    {
        nullEnterPanel.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        isOpenDialog = false;
    }

    public void ReadStringInput(string s)
    {
        inputName = s;
    }

    public void NewSetting()
    {
        SceneManager.LoadScene(3);
    }



}
