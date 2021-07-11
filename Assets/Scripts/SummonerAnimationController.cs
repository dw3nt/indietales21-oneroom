using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerAnimationController : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SummonerController controller = animator.GetComponent<SummonerController>();
        controller.canSummon = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Destroy(animator.gameObject);
    }
}
