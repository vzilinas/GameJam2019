using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject block;
    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            GameObject objectInstance = Instantiate(block, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
}
