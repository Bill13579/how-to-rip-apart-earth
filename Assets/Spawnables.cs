using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnables : MonoBehaviour
{
    public GameObject[] spawnables;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnables.Length; i++) {
            spawnables[i].SetActive(false);
        }
    }
}
