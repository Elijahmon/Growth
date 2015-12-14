using UnityEngine;
using System.Collections;

public class VineSpawner : MonoBehaviour {

	[SerializeField]
	GameObject growingVines;

    int vinesToSpawn;

	// Use this for initialization

	void Start ()
    {
        vinesToSpawn = 1;
        for (int i = 0; i < vinesToSpawn; i++)
        {
            GameObject g = (GameObject)Instantiate(growingVines, transform.position, Quaternion.identity);
            g.transform.position = new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1), transform.position.y, Random.Range(transform.position.z - 1, transform.position.z + 1));
        }

	}
	

}
