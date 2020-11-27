using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StarsManager : MonoBehaviour
{
    Image[] images;

    int actualStar = 0;
    float firstThreshold = 50;

    // Start is called before the first frame update
    void Start()
    {
        images = Canvas.FindObjectsOfType<Image>();
        foreach(Image img in images)
        {
            img.enabled = false;
        }
        Array.Reverse(images);
    }

    // Update is called once per frame
    void Update()
    {
        if(PointsCounter.pointsCounter > firstThreshold)
        {
            images[actualStar].enabled = true;
            actualStar++;
            firstThreshold *= 1.1f;
        }
    }
}
