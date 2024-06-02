using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class NpcController : MonoBehaviour
{
    [Header("ControladorDeMovimentoDoNpc")]
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public int index;
    [SerializeField] Vector3 target;
    public int estados;

    //public Image imagemVitoria;
    //public Image imagemDerrota;

    

    //------------------

    //[Header("Verifier")]
    //public GameObject playerGameObject;
    //PickUpObject pickUpObject;
    //public bool itemEntrege1;
    //public bool itemEntrege2;
    //public bool itemEntrege3;
    //public bool pedidoCompleto;
    void Update()
    {
        //pickUpObject = playerGameObject.GetComponentInChildren<PickUpObject>();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            estados++;
        }
    }

    public void UpdateDestination() 
    {
        target = waypoints[index].position;
        agent.SetDestination(target);
    }

    public void WaypointSelector() 
    {
        index++;
        if (index == waypoints.Length)
        {
            index = 0;
        }
    }

    

    //public void VerificarObjetoIgual()
    //{
    //    for (int i = 0; i < itemPedido.Length; i++)
    //    {
    //        if (itemPedido.Length >= 1)
    //        {
    //            if (pickUpObject.itemSegurado.name == itemPedido[0])
    //            {
    //                itemEntrege1 = true;
    //                pickUpObject.Disherda();
    //                pickUpObject.transform.position = pickUpObject.localOrigem.transform.position;
    //                Debug.Log("item 1 foi entregue com sucesso ITEM ENTREGE: " + itemPedido[0]);
    //            }
    //            if (itemPedido.Length == 1 && itemEntrege1)
    //            {
    //                pedidoCompleto = true;
    //            }
    //        }
    //        else
    //        {
    //            break;
    //        }

    //        if (itemPedido.Length >= 2)
    //        {
    //            if (pickUpObject.itemSegurado.name == itemPedido[1] && itemEntrege1)
    //            {
    //                itemEntrege2 = true;
    //                pickUpObject.Disherda();
    //                pickUpObject.transform.position = pickUpObject.localOrigem.transform.position;
    //                Debug.Log("item 2 foi entregue com sucessoITEM ENTREGE: " + itemPedido[1]);
    //            }
    //            if (itemPedido.Length == 2 && itemEntrege1 && itemEntrege2)
    //            {
    //                pedidoCompleto = true;
    //            }
    //        }
    //        else
    //        {
    //            break;
    //        }

    //        if (itemPedido.Length == 3)
    //        {
    //            if (pickUpObject.itemSegurado.name == itemPedido[2] && itemEntrege1 && itemEntrege2)
    //            {
    //                itemEntrege3 = true;
    //                pickUpObject.Disherda();
    //                pickUpObject.transform.position = pickUpObject.localOrigem.transform.position;
    //                Debug.Log("item 3 foi entregue com sucessoITEM ENTREGE: " + itemPedido[2]);
    //            }
    //            if (itemPedido.Length == 3 && itemEntrege1 && itemEntrege2 && itemEntrege3)
    //            {
    //                pedidoCompleto = true;
    //            }
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //}
}
