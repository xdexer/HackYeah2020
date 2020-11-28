using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{

    static public float pointsCounter = 0.0f;
    private TextMeshPro textMeshProPoints;
    private GameObject playerObj = null;
    private float playerStartPosition = 0;
    private float playerMaxPositionDifference = 0;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProPoints = gameObject.GetComponent<TextMeshPro>();
        if (playerObj == null)
        {
            this.playerObj = FindObjectOfType<PlayerController>().gameObject;
            this.playerStartPosition = this.playerObj.transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.playerMaxPositionDifference = this.playerObj.transform.position.y - this.playerStartPosition;
        if(this.playerMaxPositionDifference > pointsCounter)
        {
            pointsCounter = Mathf.Round(this.playerMaxPositionDifference);
        }
        string pointsToString = string.Format("({0})", pointsCounter);
        textMeshProPoints.SetText(pointsToString);
        
    }
}
