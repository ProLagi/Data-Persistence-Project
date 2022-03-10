using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    public Text bestScoreText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
            bestScoreText.text = "Best Score : " + SaveDataManager.Instance.bestNameSave + " : " + SaveDataManager.Instance.bestScoreSave;

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver() 
    {
        SaveDataManager.Instance.scoreSave = m_Points;
        if (SaveDataManager.Instance.scoreSave >= SaveDataManager.Instance.bestScoreSave) // ���� ���� ����� 1, �������������� all
        {
            SaveDataManager.Instance.thirdScoreSave = SaveDataManager.Instance.secondScoreSave; // 3 place
            SaveDataManager.Instance.thirdNameSave = SaveDataManager.Instance.secondNameSave;

            SaveDataManager.Instance.secondScoreSave = SaveDataManager.Instance.bestScoreSave; // 2 place
            SaveDataManager.Instance.secondNameSave = SaveDataManager.Instance.bestNameSave;

            SaveDataManager.Instance.bestScoreSave = SaveDataManager.Instance.scoreSave;       // 1 place
            SaveDataManager.Instance.bestNameSave = SaveDataManager.Instance.inputNameSave;
        }
        else if (SaveDataManager.Instance.scoreSave >= SaveDataManager.Instance.secondScoreSave) // ���� ���� ����� 2, �������������� 2 and 3
        {
            SaveDataManager.Instance.thirdScoreSave = SaveDataManager.Instance.secondScoreSave; // 3 place
            SaveDataManager.Instance.thirdNameSave = SaveDataManager.Instance.secondNameSave;

            SaveDataManager.Instance.secondScoreSave = SaveDataManager.Instance.scoreSave; // 2 place
            SaveDataManager.Instance.secondNameSave = SaveDataManager.Instance.inputNameSave;
        }
        else if (SaveDataManager.Instance.scoreSave >= SaveDataManager.Instance.thirdScoreSave) // ���� ���� ����� 3, �������������� 3
        {
            SaveDataManager.Instance.thirdScoreSave = SaveDataManager.Instance.scoreSave; // 3 place
            SaveDataManager.Instance.thirdNameSave = SaveDataManager.Instance.inputNameSave;
        }


        SaveDataManager.Instance.SaveDataNamesAndScores();

        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void NewBackScene()
    {
        SceneManager.LoadScene(0);
    }
    public void NewSettingButton()
    {
        SceneManager.LoadScene(3);
    }

    

}
