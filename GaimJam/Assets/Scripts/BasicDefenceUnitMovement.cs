using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDefenceUnitMovement: MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    public Vector2 movedir = new Vector2(0,0);
   

    // Update is called once per frame
    void Update()
    {
        moveInDirection();
    }

    void moveInDirection()
    {
        rigidbody.AddRelativeForce(movedir * speed, ForceMode2D.Force);
    }
}
