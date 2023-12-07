using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGorodki : MonoBehaviour
{
    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private GameObject[] spawnMark;

    // Start is called before the first frame update
    void Start()
    {
        spawnMark = GameObject.FindGameObjectsWithTag("SpawnMark");
    }

    public void RespawnAll()
    {
        foreach (GameObject spawn in spawnMark)
        {
            spawnManager = spawn.GetComponent<SpawnManager>();
            Destroy(spawnManager.spawnedObject);
            spawnManager.SpawnObject();
        }
    }
}
