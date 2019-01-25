using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonsterMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Transform targetToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTargetWithRotation(targetToFollow, 1, 0.2f);
    }
    void FollowTargetWithRotation(Transform target, float distanceToStop, float speed)
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            var direction = target.position - transform.position;
            rigidbody.AddRelativeForce(direction * speed, ForceMode2D.Force);
        }
    }
}
