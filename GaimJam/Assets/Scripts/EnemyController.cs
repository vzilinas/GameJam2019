using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health = 20;
    public int Damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Fort")
        {
            Health -= Damage;
        }
        if(collision.gameObject.tag == "Block")
        {
            Health -= Damage / 2;
        }
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
        direction.y = direction.y * 0.4f;
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(direction * 100, ForceMode2D.Force);

    }
}
