using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public ClimateChangeController climateChange;

    public float SpawnProbability() {
        return climateChange.GetProgress() / climateChange.maxProgress / 600;
    }
}
