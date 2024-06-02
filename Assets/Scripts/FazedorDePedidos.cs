using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class FazedorDePedidos : NetworkBehaviour
{
    [Header("Order")]
    public string[] itemPedido;
    //public string itemPedido2;
    //public string itemPedido3;
    //public TextMeshProUGUI itemPedidoTxt;

    public string[] pedidoDoCliente1;
    public string[] pedidoDoCliente2;
    public string[] pedidoDoCliente3;
    public string[] pedidoDoCliente4;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cliente1")
        {
            OrderSelector();
            pedidoDoCliente1 = itemPedido;
        }
        else
        {
            pedidoDoCliente1 = new string[1];
            pedidoDoCliente1[0] = "ainda não pediu";
        }
        if (other.name == "Cliente2")
        {
            OrderSelector();
            pedidoDoCliente2 = itemPedido;
        }
        else
        {
            pedidoDoCliente2 = new string[1];
            pedidoDoCliente2[0] = "ainda não pediu";
        }
        if (other.name == "Cliente3")
        {
            OrderSelector();
            pedidoDoCliente3 = itemPedido;
        }
        else
        {
            pedidoDoCliente3 = new string[1];
            pedidoDoCliente3[0] = "ainda não pediu";
        }
        if (other.name == "Cliente4")
        {
            OrderSelector();
            pedidoDoCliente4 = itemPedido;
        }
        else
        {
            pedidoDoCliente4 = new string[1];
            pedidoDoCliente4[0] = "ainda não pediu";
        }
    }


    public void OrderSelector()
    {
        //tamanho de pedido aleatorio
        int tamanhoPedido = Random.Range(1, 4);
        Debug.Log("tamanho do pedido " + tamanhoPedido);
        itemPedido = new string[tamanhoPedido];

        for (int i = 0; i < itemPedido.Length; i++)
        {
            //item aleatorio a ser pedido
            int randomNumber = Random.Range(0, 3);
            //lista de itens de acordo com numero aleatorio
            if (randomNumber == 0)
            {
                itemPedido[i] = "Cozido";
                Debug.Log("item " + (i + 1) + " " + itemPedido[i]);
                //itemPedidoTxt.text = itemPedido[i];
            }
            if (randomNumber == 1)
            {
                itemPedido[i] = "Salada";
                Debug.Log("item " + (i + 1) + " " + itemPedido[i]);
                //itemPedidoTxt.text += " " + itemPedido[i];
            }
            if (randomNumber == 2)
            {
                itemPedido[i] = "Bebida";
                Debug.Log("item " + (i + 1) + " " + itemPedido[i]);
                //itemPedidoTxt.text += " " + itemPedido[i];
            }
        }
    }
}
