using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSoQuePuto : StateMachineBehaviour
{
    NpcController NpcController;
    float tempoDeEspera;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NpcController = animator.GetComponent<NpcController>();
        NpcController.estadoAtual.text = "To Puto";
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (NpcController.estados == 4)
        {
            animator.SetBool("PedidoEntregue", true);
        }
        tempoDeEspera += Time.deltaTime;
        if (tempoDeEspera >= 10)
        {
            animator.SetBool("DesistirDoPedido", true);
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NpcController.UpdateDestination();
        NpcController.WaypointSelector();
    }
}
