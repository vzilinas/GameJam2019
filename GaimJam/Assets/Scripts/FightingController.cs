using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class FightingController : MonoBehaviour
    {
        public Animator animator;
        public RuntimeAnimatorController fightController;
        public bool DoneFighting;
        public Vector2 initialFriendlyVelocity;
        public Vector2 initialEnemyVector;
        void Start()
        {
            animator.StopPlayback();
        }
        void Update()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Its enemy");

                initialEnemyVector = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                initialFriendlyVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;

                Debug.Log("I stopped it");

                StartCoroutine(FightingAnimationStart(collision.gameObject));
            }
        }
        public IEnumerator FightingAnimationStart(GameObject enemy)
        {
            Debug.Log("Animation begin");
            animator.runtimeAnimatorController = fightController;
            animator.StartPlayback();
            yield return new WaitForSeconds(3f);
            animator.StopPlayback();
            Debug.Log("Animation end");
            gameObject.GetComponent<FriendlyController>().RecalculateHealthAndDirection(initialFriendlyVelocity);
            enemy.GetComponent<EnemyController>().RecalculateHealthAndDirection(initialEnemyVector);
        }
    }
}
