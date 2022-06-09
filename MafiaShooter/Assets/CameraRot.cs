using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [Header("Min Max Value Of Vertical Rotation")]
    public bool isClampVerticalRotation;
    public float verticalMinValue;
    public float verticalMaxValue;

    [Space()]
    [Header("Min Max Value Of Horizontal Rotation")]
    public bool isClampHorizontalRotation;
    public float horizontalMinValue;
    public float horizontalMaxValue;

    private Vector3 firstpoint;
    private Vector3 secondpoint;

    private float xAngle;
    private float yAngle;
    private float xAngTemp;
    private float yAngTemp;

    // Booleans
    private bool isUpdatePosition = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnStartTouch();
            isUpdatePosition = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isUpdatePosition = false;
        }

        if (isUpdatePosition)
        {
            UpdatePosition();
        }
    }

    private void OnStartTouch()
    {
        firstpoint = Input.mousePosition;

        xAngTemp = xAngle;
        yAngTemp = yAngle;
    }

    public void UpdatePosition()
    {
        secondpoint = Input.mousePosition;

        xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 80.0f / Screen.width;
        yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 100.0f / Screen.height;

        // Clamping Vertical Value
        if (isClampVerticalRotation)
        {
            yAngle = Mathf.Clamp(yAngle, verticalMinValue, verticalMaxValue);
        }

        // Clamping Horizontal Value
        if (isClampHorizontalRotation)
        {
            xAngle = Mathf.Clamp(xAngle, horizontalMinValue, horizontalMaxValue);
        }

        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
    }
}