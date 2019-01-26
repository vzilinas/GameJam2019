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
        private Animator animator;
        public RuntimeAnimatorController fightController;
        public RuntimeAnimatorController normalController;
        public bool DoneFighting = true;
        public Vector2 initialFriendlyVelocity;
        public Vector2 initialEnemyVector;
        void Start()
        {
            animator = gameObject.GetComponent<Animator>();
            //animator.StartPlayback();
        }
        void Update()
        {
            if (DoneFighting)
            {
                animator.runtimeAnimatorController = normalController;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Enemy" && 
                !collision.gameObject.GetComponent<Rigidbody2D>().isKinematic && 
                !gameObject.GetComponent<Rigidbody2D>().isKinematic)
            {
                initialEnemyVector = collision.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
                initialFriendlyVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;

                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;

                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;


                StartCoroutine(FightingAnimationStart(collision.gameObject));
            }
        }
        public IEnumerator FightingAnimationStart(GameObject enemy)
        {
            animator.runtimeAnimatorController = fightController;
            DoneFighting = false;
            enemy.GetComponent<Renderer>().enabled = false;
            animator.StopPlayback();
            yield return new WaitForSeconds(1f);
            animator.StartPlayback();
            enemy.GetComponent<Renderer>().enabled = true;
            DoneFighting = true;
            var friendController = gameObject.GetComponent<FriendlyController>();
            var enemyController = enemy.GetComponent<EnemyController>();

            friendController.RecalculateHealthAndDirection(initialFriendlyVelocity, 
                        (int)(enemyController.Damage/2));
            enemyController.RecalculateHealthAndDirection(initialEnemyVector, 
                        (int)(friendController.Damage/2));

            animator.runtimeAnimatorController = normalController;
        }
    }
}
