using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime;
    float m_spawnTime;
    bool m_isGameOver;
    int m_score;

    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
		if (m_isGameOver)
		{
            m_spawnTime = 0;
            m_ui.showGameOverPanel(true);
            return;
		}

        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
		{
            SpawnObstacle();
            m_spawnTime = spawnTime;
		}
    }
    public void SpawnObstacle()
	{
        float randYpos = Random.Range(-2.7f, -1.5f);
        Vector2 spawnPos = new Vector2(11, randYpos);
		if (obstacle)
		{
            Instantiate(obstacle, spawnPos, Quaternion.identity);
		}
	}
    public void Replay()
	{
        SceneManager.LoadScene("GamePlay");
	}
    public void SetScore(int value)
	{
        m_score = value;
	}
    public int GetScore()
	{
        return m_score;
	}
    public void ScoreIncrement()
	{
        if (m_isGameOver)
            return;
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
	}
    public bool IsGameOver()
	{
        return m_isGameOver;
	}
    public void SetGameOverState(bool state)
	{
        m_isGameOver = state;
	}

}
