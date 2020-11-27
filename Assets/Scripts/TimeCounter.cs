using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{

    public float timeCounter = 0;
    private TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update() {
    
        timeCounter += Time.deltaTime;

        float seconds = Mathf.FloorToInt(timeCounter % 60);
        float minutes = Mathf.FloorToInt(timeCounter / 60);

        string timeToString = string.Format("{00:00}:{1:00}", minutes, seconds);

        textMeshPro.SetText(timeToString);
        
    }
}
