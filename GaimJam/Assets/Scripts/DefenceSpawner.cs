using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceSpawner : MonoBehaviour
{
    public GameObject unit;                 // The unit prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Vector2 movedir;
    void Start()
    {
        // Vector3 targetToFollow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 spawnPosition  = GameObject.Find("Fort").transform.position;
        // movedir = (targetToFollow - spawnPosition).normalized;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        Vector2 spawnlocation = gameObject.GetComponent<Transform>().position;
        unit = Instantiate(unit, spawnlocation, Quaternion.Euler(new Vector3(0, 0, 0)));
        unit.GetComponent<BasicDefenceUnitMovement>().movedir = movedir;
    }
}
