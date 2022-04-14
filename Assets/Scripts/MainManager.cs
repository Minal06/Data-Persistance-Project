using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;

    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    public static string playerNameInGame;
      
    public int highScorePoints;
    public string highScoreName;


    // Start is called before the first frame update
    void Start()
    {
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
        ScoreText.text = $"{playerNameInGame} Score : {m_Points}";
        LoadHighScore();        
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
            SaveHighScore();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        HighScoreUpdate();
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{playerNameInGame} Score : {m_Points}";
    }

    [System.Serializable]
    class HighScoreEntry
    {
        public string highScoreName;
        public int highScorePoints;        
    }

    void HighScoreUpdate()
    {
        if(m_Points > highScorePoints)
        {
            highScoreName = playerNameInGame;
            highScorePoints = m_Points;
            HighScoreText.text = $"{highScoreName} Score: {highScorePoints}";
        }
    }

    public void SaveHighScore()
    {
        HighScoreEntry data = new HighScoreEntry();
        data.highScoreName = highScoreName;
        data.highScorePoints = highScorePoints;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreEntry data = JsonUtility.FromJson<HighScoreEntry>(json);

            highScoreName = data.highScoreName;
            highScorePoints = data.highScorePoints;

            HighScoreText.text = $"{highScoreName} Score : {highScorePoints}";
        }
    }



    public void GameOver()
    {
        //HighScoreList();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }   
}
