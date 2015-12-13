using UnityEngine;
using System.Collections;

public class playerCamera : MonoBehaviour
{

    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    float xSensitivity;
    [SerializeField]
    float ySensitivity;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            RotateCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
	}

    void RotateCamera(float x, float y)
    {
        transform.RotateAround(targetTransform.position, Vector3.up, x * xSensitivity);
        transform.RotateAround(targetTransform.position, Vector3.right, -y * ySensitivity);
        transform.LookAt(targetTransform);
    }
}
