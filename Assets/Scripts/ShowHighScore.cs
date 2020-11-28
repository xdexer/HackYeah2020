using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject txt;
    void Start()
    {
        int score = PlayerPrefs.GetInt("highscore");
        txt.GetComponent<UnityEngine.UI.Text>().text = "High Score: " + score;
    }

}
