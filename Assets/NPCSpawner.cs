using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPC;
    public int npcCount = 5;

    GameObject New()
    {
        GameObject npc = GameObject.Instantiate(NPC, transform.position, NPC.transform.rotation);
        npc.SetActive(true);
        return npc;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < npcCount; i++) {
            New();
        }
    }
}
