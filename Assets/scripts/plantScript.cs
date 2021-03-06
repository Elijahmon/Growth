﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class plantScript : MonoBehaviour
{
    
    public enum STATE { IDLE, MOVING, CLIMBING, GAME_OVER}
    STATE currentState = STATE.IDLE;

    [SerializeField]
    MovementController movementController;
    [SerializeField]
    Text uiWaterText;
    [SerializeField]
    Camera endGameCamera;

    [SerializeField]
    int maxWater;
    float currentWater;
    [SerializeField]
    float waterDrainRate;

    Rigidbody plantRigidbody;

	// Use this for initialization
	void Start ()
    {
        plantRigidbody = this.GetComponent<Rigidbody>();
        currentWater = maxWater / 2;
	}
	void FixedUpdate()
    {
        currentState = UpdateState();
        currentWater -= currentState == STATE.MOVING ? waterDrainRate : 0;
    }
	// Update is called once per frame
	void Update ()
    {
		if(currentWater <= 0)
		{
			currentWater = 0;
            movementController.targetTransform.GetComponent<Camera>().enabled = false;
            endGameCamera.enabled = true;
            movementController.enabled = false;
            currentState = STATE.GAME_OVER;
           

		}
        uiWaterText.text = "Water Left: " + currentWater;
	}
    STATE UpdateState()
    {
        if(plantRigidbody.velocity != Vector3.zero)
        {
            return STATE.MOVING;
        }
        return STATE.IDLE;
    }

    void OnTriggerStay(Collider coll)
    {
        if(coll.GetComponent<WaterPool>() != null)
        {
            if(coll.GetComponent<WaterPool>().DrainWater())
            {
                currentWater+= .5f;
            }
        }
        if (coll.tag == "Wall")
        {
            movementController.climbing = true;
            currentState = STATE.CLIMBING;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Wall")
        {
            movementController.climbing = false;
            currentState = STATE.MOVING;
        }
    }
}
