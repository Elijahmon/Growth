using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    [SerializeField]
    public Transform targetTransform;
    [SerializeField]
    faceMovementDirection graphicsSync;

    [SerializeField]
    int forwardSpeed;
    [SerializeField]
    int maxForwardSpeed;
    [SerializeField]
    int strafeSpeed;
    [SerializeField]
    int maxStrafeSpeed;
    
    Rigidbody playerRigidbody;
    public bool climbing = false;
	// Use this for initialization
	void Start ()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	    if(Input.GetAxis("Vertical") != 0)
        {
            MoveForward(Input.GetAxis("Vertical"));
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            Strafe(Input.GetAxis("Horizontal"));
        }
	}

    void MoveForward(float v)
    {
        Vector3 forwardDirection = targetTransform.TransformDirection(Vector3.forward);
        if(!climbing)
        {
            playerRigidbody.useGravity = true;
            forwardDirection.y = 0;
            if (!(playerRigidbody.velocity.magnitude > maxForwardSpeed))
            {
                playerRigidbody.AddForce(forwardDirection * (v * forwardSpeed));
            }
        }
        else
        {
            if (!(playerRigidbody.velocity.magnitude > maxForwardSpeed))
            {
                playerRigidbody.useGravity = false;
                playerRigidbody.AddForce(forwardDirection * (v * forwardSpeed));
            }
        }
        graphicsSync.SetMovementDirection(transform.InverseTransformDirection(playerRigidbody.velocity));
    }
    void Strafe(float h)
    {
        Vector3 rightDirection = targetTransform.TransformDirection(Vector3.right);
        rightDirection.y = 0;
        if(!(playerRigidbody.velocity.magnitude > maxStrafeSpeed))
        {
            playerRigidbody.AddForce(rightDirection * (h * strafeSpeed));
        }
        graphicsSync.SetMovementDirection(transform.InverseTransformDirection(playerRigidbody.velocity));
    }
}
