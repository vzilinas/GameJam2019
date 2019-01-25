using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceSpawner : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //targetToFollow = GameObject.Find("Fort").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
