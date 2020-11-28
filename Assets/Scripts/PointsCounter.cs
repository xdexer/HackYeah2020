using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{

    static public float pointsCounter = 0.0f;
    private TextMeshPro textMeshProPoints;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProPoints = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        string pointsToString = string.Format("({0})", Mathf.Round(pointsCounter));
        textMeshProPoints.SetText(pointsToString);
        pointsCounter += 0.05f;
        
    }
}
