using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseLog : PatrolLog
{
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && (currentState == EnemyState.idle || currentState == EnemyState.walk)
            && currentState != EnemyState.stagger)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // движение до точки с которой может произвести атаку по цели.
            ChangeAnimation(temp - transform.position);
            myRigidbody.MovePosition(temp);            
            animator.SetBool("wakeUp", true);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[0].position) > raundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[0].position, moveSpeed * Time.deltaTime); // движение до точки с которой может произвести атаку по цели.
                ChangeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
            else
            {
                currentGoal = path[0];
                animator.SetBool("wakeUp", false);
                currentState = EnemyState.idle;
            }
        }
    }
}
