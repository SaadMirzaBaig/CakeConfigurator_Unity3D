using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{

    public float rotationSpeed = 10f;
    private Vector3 _lastMousePosition;

    public float scaleSpeed = 0.5f;
    public float minScale = 0.5f;
    public float maxScale = 2.0f;
    private bool isScaling = false;
    private Vector3 startScale;


    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = currentMousePosition.x - _lastMousePosition.x;
            float deltaY = currentMousePosition.y - _lastMousePosition.y;

            transform.Rotate(Vector3.up, -deltaX * rotationSpeed * Time.deltaTime, Space.Self);
            // Remove the next line to prevent rotation on the Y-axis
            //transform.Rotate(Vector3.right, deltaY * rotationSpeed * Time.deltaTime, Space.Self);
        }

        _lastMousePosition = Input.mousePosition;


        if (!isScaling && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ScaleCube());
        }


    }

    IEnumerator ScaleCube()
    {
        isScaling = true;

        Vector3 endScale = Vector3.zero;
        if (transform.localScale == startScale)
        {
            endScale = new Vector3(2f, 2f, 2f);
        }
        else
        {
            endScale = startScale;
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(transform.localScale, endScale, t);
            yield return null;
        }

        isScaling = false;
    }
}
