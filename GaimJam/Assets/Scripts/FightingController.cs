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
        public Animator fightingAnimator;
        public bool DoneFighting;
        public Vector2 initialFriendlyVelocity;
        public Vector2 initialEnemyVector;
        void Start()
        {
            
        }
        void Update()
        {
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(gameObject.tag == "Enemy")
            {
                initialEnemyVector = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                initialFriendlyVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                StartCoroutine(FightingAnimationStart(collision.gameObject));
            }
        }
        public IEnumerator FightingAnimationStart(GameObject enemy)
        {
            fightingAnimator.StartPlayback();
            yield return new WaitForSeconds(3f);
            fightingAnimator.StopPlayback();
            gameObject.GetComponent<FriendlyController>().RecalculateHealthAndDirection(initialFriendlyVelocity);
            enemy.GetComponent<EnemyController>().RecalculateHealthAndDirection(initialFriendlyVelocity);
        }
    }
}
