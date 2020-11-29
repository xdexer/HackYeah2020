using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour
{
    private static int HighScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        HighScore = 0;

    }

    public void GameOver()
    {
        int score = (int)PointsCounter.pointsCounter;
        if (score > HighScore)
            HighScore = score;
        PointsCounter.pointsCounter = 0;
        Debug.Log(HighScore);
        PlayerPrefs.SetInt("highscore", HighScore);
        SceneManager.LoadScene("MainMenu");
    }
}
