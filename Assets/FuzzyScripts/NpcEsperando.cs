using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcEsperando : StateMachineBehaviour
{
    NpcController NpcController;
    float tempoDeEspera;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NpcController = animator.GetComponent<NpcController>();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //2
        NpcController.UpdateDestination();
        NpcController.WaypointSelector();
        //3
    }
}
