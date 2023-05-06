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
    public bool isScaling = false;
    private Vector3 startScale;

    private bool isMouseDragging = false;

    private Vector3 lastMousePosition;
    private Vector3 lastCubeRotation;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;

        lastMousePosition = Input.mousePosition;
        lastCubeRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                isMouseDragging = true;
            }
            _lastMousePosition = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        if (isMouseDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = currentMousePosition.x - _lastMousePosition.x;
            float deltaY = currentMousePosition.y - _lastMousePosition.y;

            transform.Rotate(Vector3.up, -deltaX * rotationSpeed * Time.deltaTime, Space.Self);
            // Remove the next line to prevent rotation on the Y-axis
            //transform.Rotate(Vector3.right, deltaY * rotationSpeed * Time.deltaTime, Space.Self);
        }


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
