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
    public GameObject hidingPanel;

    public Text bestScoreText;
    public Text secondScoreText;
    public Text thirdScoreText;

    private void Start()
    {
        bestScoreText.text = $"Best Score: {SaveDataManager.Instance.bestNameSave}: score {SaveDataManager.Instance.bestScoreSave}";
        secondScoreText.text = $"Second Score: {SaveDataManager.Instance.secondNameSave}: score {SaveDataManager.Instance.secondScoreSave}";
        thirdScoreText.text = $"Third Score: {SaveDataManager.Instance.thirdNameSave}: score {SaveDataManager.Instance.thirdScoreSave}";

        hidingPanel.SetActive(false);
        if (SaveDataManager.Instance.inputNameSave != null)
        {
            inputName.text = SaveDataManager.Instance.inputNameSave;
            openBestScore.text = "Best Score: " + SaveDataManager.Instance.bestNameSave + " : score " + SaveDataManager.Instance.bestScoreSave;
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

    public void HidingTopDarkPanel()
    {
        hidingPanel.SetActive(false);
    }
    public void OpenTopDarkPanel()
    {
        hidingPanel.SetActive(true);
    }




}
