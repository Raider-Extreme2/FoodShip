using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSoQuePuto : StateMachineBehaviour
{
    NpcController NpcController;
    [Header("SoundEffect")]
    public AudioClip npcIrritado;
    public AudioClip npcPedindo;
    public AudioSource tocadorDeSon;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NpcController = animator.GetComponent<NpcController>();
        tocadorDeSon = animator.GetComponent<NpcController>().gameObject.GetComponent<AudioSource>();
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tocadorDeSon.clip = npcIrritado;
        tocadorDeSon.Play();
        //2
        //NpcController.index = 2;
        NpcController.UpdateDestination();
        NpcController.WaypointSelector();
        //3
    }
}
