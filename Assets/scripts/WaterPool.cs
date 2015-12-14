using UnityEngine;
using System.Collections;

public class WaterPool : MonoBehaviour {

    [SerializeField]
    int poolAmount;
    int waterLeft;

    void Start()
    {
        waterLeft = poolAmount;
    }

    public bool DrainWater()
    {
        if(waterLeft > 0)
        {
            waterLeft -= 1;
            transform.localScale = new Vector3(transform.localScale.x - .05f, transform.localScale.y - .05f, transform.localScale.z - .05f);
            return true;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            return false;
        }
    }

}
