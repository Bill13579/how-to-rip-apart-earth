using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public bool interactive;
    public GameObject autoSpawn;
    public SpawnController spawnController;

    private enum State { Free, Ready, Locked };
    private State m_State;

    public GameObject New(GameObject go) {
        GameObject newGo = GameObject.Instantiate(go, transform.position, go.transform.rotation);
        newGo.SetActive(true);
        return newGo;
    }

    public void OnMouseDown() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_State == State.Free) {
            if (!interactive && Random.value < spawnController.SpawnProbability()) {
                New(autoSpawn);
                m_State = State.Locked;
            } else if (interactive) {
                New(autoSpawn);
                m_State = State.Ready;
            }
        }
    }
}
