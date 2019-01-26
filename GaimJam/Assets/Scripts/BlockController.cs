using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // States change when hp is reduced
    public List<Sprite> States = new List<Sprite>();
    public float Health;

    private float currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var damage = collision.gameObject.GetComponent<EnemyModel>().Damage;
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                // Sets new sprite according to current hp
                GetComponent<SpriteRenderer>().sprite = States[(int)((1 - currentHealth / Health) * States.Count)];
            }
        }
    }
}

