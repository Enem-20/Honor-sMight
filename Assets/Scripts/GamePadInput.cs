using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInput : MonoBehaviour
{
    CharacterController _charControl;

    private float RotationXgmpd;
    private float RotationYgmpd;
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    public float SensitivityHor = 9.0f;
    public float SensitivityVert = 9.0f;
    private float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            _charControl = GetComponent<CharacterController>();

            ///////////////////////////////////////////////////Left Stick

            float deltaX = Input.GetAxis("Left_XAxis_1") * speed;
            float deltaZ = -Input.GetAxis("Left_YAxis_1") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charControl.transform.position += movement;

            ///////////////////////////////////////////////////Right Stick

            if ((Input.GetAxis("R_XAxis_1") != 0) && (Input.GetAxis("R_YAxis_1") == 0))
            {
                transform.Rotate(0, Input.GetAxis("R_XAxis_1"), 0);
            }
            else if ((Input.GetAxis("R_YAxis_1") != 0) && (Input.GetAxis("R_XAxis_1") == 0))
            {
                RotationXgmpd += Input.GetAxis("R_YAxis_1");
                RotationXgmpd = Mathf.Clamp(RotationXgmpd, minimumVert, maximumVert);

                float RotationYgmpd = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(RotationXgmpd, RotationYgmpd, 0);
            }
            else if (!(Input.GetAxis("R_XAxis_1") == 0) && !(Input.GetAxis("R_YAxis_1") == 0))
            {
                RotationXgmpd += Input.GetAxis("R_YAxis_1");
                RotationXgmpd = Mathf.Clamp(RotationXgmpd, minimumVert, maximumVert);

                float delta = Input.GetAxis("R_XAxis_1");
                float RotationYgmpd = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(RotationXgmpd, RotationYgmpd, 0);
            }
        }
    }
}
