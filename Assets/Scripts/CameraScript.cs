using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private GameObject playerObj = null;
    private bool isCameraMoving = false;
    private float startCameraMovement = 0;
    private float cameraMultiplier = 0.15f;
    private float nextCameraSpeedUpPoint = 25;
    private float cameraHeight = 2f * Camera.main.orthographicSize;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
        {
            this.playerObj = FindObjectOfType<PlayerController>().gameObject;
            this.startCameraMovement = playerObj.transform.position.y + 3;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.playerObj.transform.position.y > this.startCameraMovement)
        {
            this.isCameraMoving = true;
        }

        if (PointsCounter.pointsCounter > nextCameraSpeedUpPoint)
        {
            nextCameraSpeedUpPoint *= 2;
            cameraMultiplier += 0.15f;
        }

        Debug.Log(cameraHeight);

        if(this.isCameraMoving == true)
        {
            float step = this.cameraMultiplier * Time.deltaTime;
            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;
        }
    }
}
