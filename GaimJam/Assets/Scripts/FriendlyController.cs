using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecalculateHealthAndDirection(Vector2 initialDirection)
    {
        var direction = -initialDirection;
        direction.y = direction.y * 0.3f; 
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(direction * 100f, ForceMode2D.Force);
        return;
    }
}
