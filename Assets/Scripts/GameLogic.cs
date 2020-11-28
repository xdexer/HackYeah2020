using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour
{
    private static int HighScore = 0;
    public PointsCounter points;
    // Start is called before the first frame update
    void Start()
    {
        HighScore = 0;

    }

    public void GameOver()
    {
        int score =(int)points.getScore();
        if (score > HighScore)
            HighScore = score;
        Debug.Log(HighScore);
        PlayerPrefs.SetInt("highscore", HighScore);
        SceneManager.LoadScene("MainMenu");
    }
}
