using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyController : MonoBehaviour
{
    public int Health = 30;
    public int Damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecalculateHealthAndDirection(Vector2 initialDirection, int damageTaken)
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        Health -= damageTaken;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
        var direction = -initialDirection;
        direction.y = direction.y * 0.3f; 
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(direction * 100f, ForceMode2D.Force);
    }
}
