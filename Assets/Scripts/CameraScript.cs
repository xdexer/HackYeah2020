using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private GameObject playerObj = null;
    private Camera camera;
    private bool isCameraMoving = false;
    private float startCameraMovement = 0;
    private float cameraMultiplier = 0.2f;
    private float nextCameraSpeedUpPoint = 25;
    private float cameraDistance = 0;
    public float cameraSensitivity = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
        {
            this.playerObj = FindObjectOfType<PlayerController>().gameObject;
            this.startCameraMovement = playerObj.transform.position.y + 3;
            this.camera = Camera.main;
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


        double cameraDist = (2f * camera.orthographicSize) + camera.transform.position.y;

        double cameraDiff = cameraDist - playerObj.transform.position.y;

        if (cameraDiff < 8)
        {
            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += 9;
            Camera.main.gameObject.transform.position = Vector3.Lerp(Camera.main.gameObject.transform.position, cameraPosition, Time.deltaTime * cameraSensitivity);
        }

        if (this.isCameraMoving == true)
        {
            float step = this.cameraMultiplier * Time.deltaTime;
            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;
        }
    }
}
