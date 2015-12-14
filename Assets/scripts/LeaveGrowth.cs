﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaveGrowth : MonoBehaviour
{

    Vector3 lastGrowthPosition;
    [SerializeField]
    float growthoffset;
    [SerializeField]
    GameObject growthPrefab;
    List<GameObject> growthObjects = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        lastGrowthPosition = transform.position;
        //Instantiate(growthPrefab, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
            if (Vector3.Distance(lastGrowthPosition, transform.position) > growthoffset)
            {
                // Debug.Log(Vector3.Distance(lastGrowthPosition, transform.position));
                PlantGrowth();
            }
	}

    void PlantGrowth()
    {
        GameObject g = (GameObject)Instantiate(growthPrefab, transform.position, transform.rotation);
        growthObjects.Add(g);
        g.transform.SetParent(GameObject.Find("Vines").transform);
        if(growthObjects.Count > 0)
        {
            
        }
        lastGrowthPosition = g.transform.position;
    }
}
