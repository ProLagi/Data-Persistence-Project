using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject nullEnterPanel;
    public GameObject settingButton;
    public SaveDataManager saveDataMeneger;
    private bool isOpenDialog;

    public InputField inputName;
    public Text openBestScore;

    private void Start()
    {
        if (SaveDataManager.Instance.inputNameSave != null)
        {
            inputName.text = SaveDataManager.Instance.inputNameSave;
            openBestScore.text = "Best Score: " + SaveDataManager.Instance.inputNameSave + " : score " + SaveDataManager.Instance.bestScoreSave;
            openBestScore.gameObject.SetActive(true);
        }
        isOpenDialog = false;
    }

    public void ReadStringInput()
    {
        Debug.Log("name = " + inputName.text);
        SaveDataManager.Instance.inputNameSave = inputName.text;
    }

    public void NewPlayScene()
    {
        Debug.Log(inputName.text + " hmm");
        if (!isOpenDialog)
        {
            if (inputName.text == null)
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

    public void NewSetting()
    {
        SceneManager.LoadScene(3);
    }

    


}
