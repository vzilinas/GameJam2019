using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceSpawner : MonoBehaviour
{
    public GameObject unit;                 // The unit prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    Vector2 movedir;
    void Start()
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetToFollow = GameObject.Find("Fort").transform.position;
        movedir = (spawnPosition - targetToFollow).normalized;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        unit = Instantiate(unit, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        unit.GetComponent<BasicDefenceUnitMovement>().movedir = movedir;
    }
}
