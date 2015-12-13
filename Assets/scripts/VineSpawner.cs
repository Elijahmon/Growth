using UnityEngine;
using System.Collections;

public class VineSpawner : MonoBehaviour {

	[SerializeField]
	GameObject growingVines;

	// Use this for initialization
	void Start () {
		GameObject g = (GameObject)Instantiate(growingVines, transform.position, Quaternion.identity);

	}
	

}
