using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Camera cam;
    bool isDragging = false;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        GM.instance.startGame();
    }

    private void OnMouseDrag()
    {
        Vector3 fingerPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = new Vector3(fingerPosition.x, fingerPosition.y, 0);
        transform.position = targetPos;
    }

    private void OnMouseUp()
    {
        GM.instance.pauseGame();
        isDragging = false;
    }
}
