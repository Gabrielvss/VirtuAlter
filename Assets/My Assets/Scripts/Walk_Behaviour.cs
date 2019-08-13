using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk_Behaviour : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       /* if (animator.GetComponent<NavMeshAgent>().isStopped)
        {
            animator.GetComponent<NavMeshAgent>().isStopped = false;
        }*/

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float speed = animator.GetComponent<PlayerController>().speed;
        //Transform destination = animator.GetComponent<PlayerController>().GetCurrentDestination();
        //animator.GetComponent<NavMeshAgent>().SetDestination(destination.position);
        animator.transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        /*if (!animator.GetComponent<NavMeshAgent>().isStopped)
        {
            animator.GetComponent<NavMeshAgent>().isStopped = true;
        }*/
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
