using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 1f;
    public GameObject focusObject;

    private Vector3 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            Vector3 panVector = new Vector3(-deltaMousePosition.x, 0, -deltaMousePosition.y);
            transform.position += panVector * panSpeed * Time.deltaTime;
        }

        lastMousePosition = Input.mousePosition;
    }


}
