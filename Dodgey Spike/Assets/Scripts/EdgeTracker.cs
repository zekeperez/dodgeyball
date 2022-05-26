using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTracker : MonoBehaviour
{
    Camera cam;
    public GameObject leftEdge;
    public GameObject rightEdge;
    public GameObject topEdge;
    public GameObject bottomEdge;

    public GameObject topLeftSpawner;
    public GameObject topRightSpawner;
    public GameObject bottomRightSpawner;
    public GameObject bottomLeftSpawner;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        #region edges
        Vector3 leftPos = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight / 2, 10));
        leftPos = new Vector3(leftPos.x - 0.5f, leftPos.y, leftPos.z);
        leftEdge.transform.position = leftPos;

        Vector3 rightPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight / 2, 10));
        rightPos = new Vector3(rightPos.x + 0.5f, rightPos.y, rightPos.z);
        rightEdge.transform.position = rightPos;

        Vector3 topPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 10));
        topPos = new Vector3(topPos.x, topPos.y + 0.5f, topPos.z);
        topEdge.transform.position = topPos;

        Vector3 bottomPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, 0, 10));
        bottomPos = new Vector3(bottomPos.x, bottomPos.y - 0.5f, bottomPos.z);
        bottomEdge.transform.position = bottomPos;
        #endregion edges

        #region spawners
        Vector3 topLeftCorner = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 10));
        topLeftCorner = new Vector3(topLeftCorner.x + 0.5f, topLeftCorner.y - 0.5f, topLeftCorner.z);
        topLeftSpawner.transform.position = topLeftCorner;
        
        Vector3 topRightCorner = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 10));
        topRightCorner = new Vector3(topRightCorner.x - 0.5f, topRightCorner.y - 0.5f, topRightCorner.z); 
        topRightSpawner.transform.position = topRightCorner;

        Vector3 rightBottomCorner = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, 10));
        rightBottomCorner = new Vector3(rightBottomCorner.x - 0.5f, rightBottomCorner.y + 0.5f, rightBottomCorner.z);
        bottomRightSpawner.transform.position = rightBottomCorner;

        Vector3 bottomLeftPos = cam.ScreenToWorldPoint(new Vector3(0, 0, 10));
        bottomLeftPos = new Vector3(bottomLeftPos.x + 0.5f, bottomLeftPos.y + 0.5f, bottomLeftPos.z);
        bottomLeftSpawner.transform.position = bottomLeftPos;
        #endregion
    }
}
