using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{

    public ControlStateController stateControler;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateControler.ChangeState(ControlState.BlockCreation);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            stateControler.ChangeState(ControlState.TeddyCreation);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            stateControler.ChangeState(ControlState.HatchCreation);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stateControler.ChangeState(ControlState.Default);
        }
    }
}
