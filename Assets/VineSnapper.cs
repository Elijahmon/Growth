using UnityEngine;
using System.Collections;

public class VineSnapper : MonoBehaviour {


    [SerializeField]
    public Transform endSnap;

    void Awake()
    {
        endSnap = this.transform.GetChild(0).transform.GetChild(1);
    }
}
