using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcIrEmbora : StateMachineBehaviour
{
    NpcController NpcController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NpcController = animator.GetComponent<NpcController>();
        if (NpcController.pedidoCompleto)
        {
            NpcController.estadoAtual.text = "Obrigado pela comida";
            NpcController.itemPedidoTxt.text = "";
            NpcController.imagemVitoria.gameObject.SetActive(true);
        }
        else
        {
            NpcController.estadoAtual.text = "Desisto do pedido";
            NpcController.itemPedidoTxt.text = "";
            NpcController.imagemDerrota.gameObject.SetActive(true);
        }
    }
}
