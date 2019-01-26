using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelScript : MonoBehaviour
{
    public int CurrentAction = 0;
    public bool StartNextAction = false;
    public IEnumerator[] Script;
    // Start is called before the first frame update
    void Start()
    {
        Script = new IEnumerator[] {
            LogText(2f, "Log this text"),
            LogText(3f, "Log this other text")
        };
        StartNextAction = true;
        //MonoBehaviourExtensions.Invoke(this, GetMetod, 0);
    }
    public IEnumerator LogText(float delay, string whatToLog)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(whatToLog);
        StartNextAction = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(StartNextAction && Script.Length == CurrentAction)
        {
            StartNextAction = false;
        }
        else if(StartNextAction == true)
        {
            StartNextAction = false;
            StartCoroutine(Script[CurrentAction]);
            CurrentAction += 1;
        }
    }
}
