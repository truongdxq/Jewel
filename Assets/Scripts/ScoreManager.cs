using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 400;
    public Text tScore, tTime;
    public int timePerLevel = 30;
    public GameObject youWon, gameOver;

    private float clockSpeed = 1f;
    // Use this for initialization
    void Start()
    {
        tScore.text = "Score: " + score + "/" + targetScore;
        InvokeRepeating("Clock", 0, clockSpeed);
    }

    void Clock()
    {
        timePerLevel--;
        tTime.text = "Time: " + timePerLevel;
        if (timePerLevel == 0)
        {
            CheckGameOver();
        }
    }
    public void AddPoint(int point)
    {
        score += point;
        tScore.text = "Score: " + score + "/" + targetScore;
    }

    void CheckGameOver()
    {
        if (score >= targetScore)
        {
            youWon.SetActive(true);
        }
        else
        {

            gameOver.SetActive(true);

        }
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
