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
            return true;
        }
        else
        {
            return false;
        }
    }

}
