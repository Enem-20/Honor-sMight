using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    { 
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float SensitivityHor = 1f;
    public float SensitivityVert = 1f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        body.freezeRotation = true;

    }

    void Update()
    {
        if ((Input.GetAxis("Vertical") != 0) && (Input.GetAxis("Horizontal") == 0))
            transform.Translate(0, 0, Input.GetAxis("Vertical") * 10);

        else if((Input.GetAxis("Vertical") == 0) && (Input.GetAxis("Horizontal") != 0))
            transform.Translate(Input.GetAxis("Horizontal") * 10, 0, 0);
        else
        {
            transform.Translate(Input.GetAxis("Horizontal") * 0.5f * 10, 0, Input.GetAxis("Vertical") * 0.5f * 10);
        }


        if (Input.GetMouseButton(1))
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("MouseX") * SensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("MouseY") * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("MouseY") * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float delta = Input.GetAxis("MouseX") * SensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}
