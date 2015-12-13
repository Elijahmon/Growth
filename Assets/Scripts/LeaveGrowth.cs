using UnityEngine;
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
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Vector3.Distance(lastGrowthPosition, transform.position) > growthoffset)
        {
            PlantGrowth();
        }
	}

    void PlantGrowth()
    {
        GameObject g = (GameObject)Instantiate(growthPrefab, transform.position, transform.rotation);
        growthObjects.Add(g);
        lastGrowthPosition = g.transform.position;
    }
}
