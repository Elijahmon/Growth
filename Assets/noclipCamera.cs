using UnityEngine;
using System.Collections;

public class noclipCamera : MonoBehaviour {

        Transform target;
        float smoothTime = 0.3f;
        private Vector3 velocity = Vector3.zero;
        private bool colliding = false;

 
void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Wall" || coll.tag == "Floor")
            colliding = true;
    }



void OnTriggerExit()
    {
        colliding = false;
    }


    void Update()
    {
        if (colliding)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(0, 1, 0), ref velocity, smoothTime);
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.forward, out hit, 1.5f))
            {
               
            }
            else
            {
                transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(0, 3.5f, -6), ref velocity, smoothTime);
            }
        }
    }
}
