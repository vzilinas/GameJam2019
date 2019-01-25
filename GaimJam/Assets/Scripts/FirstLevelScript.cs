using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelScript : MonoBehaviour
{
    Dictionary<int, string> methodProgress;
    // Start is called before the first frame update
    void Start()
    {
        MonoBehaviourExtensions.Invoke(this, GetMetod, 0);
    }
    void GetMetod()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
