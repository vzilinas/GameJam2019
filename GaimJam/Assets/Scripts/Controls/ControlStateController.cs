using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStateController : MonoBehaviour
{
    private ControlState currentState;

    public GameObject defenceBlock;
    public GameObject defenceSpawner;
    public GameObject enemySpawner;
    public void ChangeState(ControlState newState)
    {
        if (newState != currentState)
        {
            switch (newState)
            {
                case ControlState.TeddyCreation:
                    break;
                case ControlState.BlockCreation:
                    break;
                case ControlState.Default:
                    break;
                default:
                    break;
            }
            currentState = newState;
            Debug.Log(newState);
        }
    }
   
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ControlState.TeddyCreation:
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 targetToFollow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 spawnPosition  = GameObject.Find("Fort").transform.position;
                    Vector2 movedir = (targetToFollow - spawnPosition).normalized;
                    GameObject defenceSpawnerObject = Instantiate(defenceSpawner, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                    defenceSpawnerObject.GetComponent<DefenceSpawner>().movedir = movedir;
                }
                break;

            case ControlState.BlockCreation:
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0.0f;
                    Instantiate(defenceBlock, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                break;
            case ControlState.HatchCreation:
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0.0f;
                    Instantiate(enemySpawner, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                break;
            default:
                break;
        }
    }
}
