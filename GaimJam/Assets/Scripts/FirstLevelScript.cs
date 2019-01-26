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
            LogText(2f, "Log this text"),       // gal reikia padaryti, kad priimtų veikėjo klasę kas kalba ir atvaizuotų profilį beigi vardą
            LogText(3f, "Log this other text")  // ir išviso, gal ne laikas, o paspaudus mygtuką turėtų pereiti į kitą dialogą
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
