using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortController : MonoBehaviour
{
    public int Health = 1000;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var damage = collision.gameObject.GetComponent<EnemyController>().Damage;
            Health -= damage;
        }
    }
}
