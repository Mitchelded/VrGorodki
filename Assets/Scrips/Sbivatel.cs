using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sbivatel : MonoBehaviour
{

    [SerializeField] private Transform spawnMark;

    [SerializeField] private Transform spawnedObject;
    // Start is called before the first frame update
    void Start()
    {
        spawnMark = GameObject.FindGameObjectWithTag("SbivatelSpawnMark").GetComponent<Transform>();
        spawnedObject = GetComponent<Transform>();

    }

    public void SpawnObject()
    {
        spawnedObject.position = spawnMark.position;
    }

}
