using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class El8abyWalking : StateMachineBehaviour
{
    public string gameObjectTag;
    private GameObject objectToFollow;
    public float speed = 0.2f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, objectToFollow.transform.position) > 2)
        {
            Vector3 tempPos = objectToFollow.transform.position;
            tempPos.y = 0;
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, tempPos, speed * Time.deltaTime);

            var lookPos = objectToFollow.transform.position - animator.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, Time.deltaTime * 10f);


        }
        else
        {
            animator.SetBool("isAttacking", true);
        }
    }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
