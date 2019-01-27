using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlStateController : MonoBehaviour
{
    private ControlState currentState;

    public GameObject defenceBlock;
    public GameObject defenceSpawner;
    public GameObject enemySpawner;
    public GameObject defenceBlockCooldownImage;
    public GameObject defenceSpawnerCooldownImage;

    public Dictionary<ControlState, float> cooldowns = new Dictionary<ControlState, float>() {
        { ControlState.BlockCreation, 1f},
        { ControlState.TeddyCreation, 35f},
    };
    public Dictionary<ControlState, float> lastCasted = new Dictionary<ControlState, float>() {
        { ControlState.BlockCreation, 0f},
        { ControlState.TeddyCreation, -20f},
    };

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
        }
    }
   
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.time;
        switch (currentState)
        {
            case ControlState.TeddyCreation:

                if (CanBeCasted(currentState, timeNow))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector3 targetToFollow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector3 spawnPosition = GameObject.Find("Fort").transform.position;
                        Vector2 movedir = (targetToFollow - spawnPosition).normalized;
                        GameObject defenceSpawnerObject = Instantiate(defenceSpawner, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                        defenceSpawnerObject.GetComponent<DefenceSpawner>().movedir = movedir;
                        GoIntoCooldown(currentState, timeNow);
                    }
                }
                break;

            case ControlState.BlockCreation:
                if (CanBeCasted(currentState, timeNow))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        spawnPosition.z = 0.0f;
                        Instantiate(defenceBlock, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                        GoIntoCooldown(currentState, timeNow);
                    }
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
        UpdateCooldowns(timeNow);
    }

    private void UpdateCooldowns(float time)
    {
        defenceBlockCooldownImage.GetComponent<Image>().fillAmount = Math.Min((time - lastCasted[ControlState.BlockCreation]) / cooldowns[ControlState.BlockCreation], 1f);
        defenceSpawnerCooldownImage.GetComponent<Image>().fillAmount = Math.Min((time - lastCasted[ControlState.TeddyCreation]) / cooldowns[ControlState.TeddyCreation], 1f);
    }

    private bool CanBeCasted(ControlState ability, float time)
    {   
        return time > lastCasted[ability] + cooldowns[ability];
    }

    private void GoIntoCooldown(ControlState ability, float time)
    {
        lastCasted[ability] = time;
    }
    







}
