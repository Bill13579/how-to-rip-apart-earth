using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimateEffector : MonoBehaviour
{
    public float PPS = 1;
    public bool makesMoney = false;
    public ClimateChangeController controller;

    void Start()
    {
        InvokeRepeating("UpdateClimate", 0f, 1f);
    }

    void UpdateClimate()
    {
        controller.DeltaProgress(PPS, makesMoney);
    }
}
