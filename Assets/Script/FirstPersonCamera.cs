using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public float moveSpeed = 2.0F;

    private Vector3 targetTransform;
    private Vector3 originalTransform;
    private float originalZoomLevel;
    private float targetZoomLevel;

    private float startTime;
    private float journeyLength;
    private bool isZoom;
    private bool isMove;
    private Camera cam;
    private Crosshair crosshair;

    void Start()
    {
        isMove = true;
        isZoom = false;
        cam = GetComponent<Camera>();
        crosshair = GetComponentInChildren<Crosshair>();
    }

    void Update()
    {
        if (isZoom)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.LookAt(Vector3.Lerp(originalTransform, targetTransform, fracJourney));
            cam.fieldOfView = Mathf.Lerp(originalZoomLevel, targetZoomLevel, fracJourney);
            if (fracJourney > 1.0f)
            {
                isZoom = false;
            }
        }
        if (isMove)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(-v, h, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }

    public float ZoomTo(Vector3 obj, float zoomLevel)
    {
        targetZoomLevel = zoomLevel;
        originalZoomLevel = cam.fieldOfView;
        targetTransform = obj;
        originalTransform = transform.position + transform.forward;
        startTime = Time.time;
        journeyLength = Vector3.Distance(originalTransform, targetTransform);
        isZoom = true;
        isMove = false;
        if (crosshair != null)
        {
            crosshair.gameObject.SetActive(false);
        }
        return journeyLength / moveSpeed;
    }

    public float CancelZoom()
    {
        targetZoomLevel = originalZoomLevel;
        originalZoomLevel = cam.fieldOfView;
        targetTransform = originalTransform;
        originalTransform = transform.position + transform.forward;
        startTime = Time.time;
        journeyLength = Vector3.Distance(originalTransform, targetTransform);
        isZoom = true;
        Invoke("AfterCancel", journeyLength / moveSpeed);
        return journeyLength / moveSpeed;
    }

    public void AfterCancel()
    {
        if (crosshair != null)
        {
            crosshair.gameObject.SetActive(true);
        }
        isMove = true;
    }
}
