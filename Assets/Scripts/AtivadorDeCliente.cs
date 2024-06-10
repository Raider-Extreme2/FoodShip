using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtivadorDeCliente : NetworkBehaviour
{
    public FazedorDePedidos DeusExMachina;

    public GameObject cliente1;
    public GameObject Animacaoliente1;

    public GameObject cliente2;
    public GameObject Animacaoliente2;

    public GameObject cliente3;
    public GameObject Animacaoliente3;

    public GameObject cliente4;
    public GameObject Animacaoliente4;

    public float tempoElapsadoCliente1;

    public float tempoElapsadoCliente2;

    public float tempoElapsadoCliente3;

    public float tempoElapsadoCliente4;

    public bool cliente1Desistiu;
    public bool cliente2Desistiu;
    public bool cliente3Desistiu;
    public bool cliente4Desistiu;

    [ServerRpc]
    public void DerrotaServerRpc() 
    {
        if (!IsServer)
        {
            return;
        }
        if (cliente1Desistiu && cliente2Desistiu)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("CenaDeDerrota", UnityEngine.SceneManagement.LoadSceneMode.Single);
            //NetworkManager.Singleton.Shutdown();
        }
        if (cliente1Desistiu && cliente3Desistiu) 
        {
            NetworkManager.Singleton.SceneManager.LoadScene("CenaDeDerrota", UnityEngine.SceneManagement.LoadSceneMode.Single);
            //NetworkManager.Singleton.Shutdown();
        }
        if (cliente2Desistiu && cliente3Desistiu)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("CenaDeDerrota", UnityEngine.SceneManagement.LoadSceneMode.Single);
            //NetworkManager.Singleton.Shutdown();
        }
    }

    private void Update()
    {
        DerrotaServerRpc();

        #region Ativar Cliente1
        tempoElapsadoCliente1 += Time.deltaTime;
        if (tempoElapsadoCliente1 >= 2 && tempoElapsadoCliente1 < 13)
        {
            cliente1.GetComponent<Animator>().SetBool("Existo", true);
            Animacaoliente1.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente1 > 13 && tempoElapsadoCliente1 < 15)
        {
            Animacaoliente1.GetComponent<Animator>().SetBool("Walking", false);
        }
        if (tempoElapsadoCliente1 > 15 && tempoElapsadoCliente1 < 18)
        {
            cliente1.GetComponent<Animator>().SetBool("FoiAtendido", true);
            Animacaoliente1.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente1 >= 19 && tempoElapsadoCliente1 <= 30)
        {
            Animacaoliente1.GetComponent<Animator>().SetBool("Walking", false);
            Animacaoliente1.GetComponent<Animator>().SetBool("Sentado", true);
        }
        if (tempoElapsadoCliente1 >= 30)
        {
            cliente1.GetComponent<Animator>().SetBool("Demorando", true);
        }
        if (DeusExMachina.pedido1Completo)
        {
            cliente1.GetComponent<Animator>().SetBool("PedidoEntregue", true);
            Animacaoliente1.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente1.GetComponent<Animator>().SetBool("Walking", true);
            tempoElapsadoCliente1 = 40;
        }
        if (tempoElapsadoCliente1 >= 40 && !DeusExMachina.pedido1Completo)
        {
            cliente1.GetComponent<Animator>().SetBool("DesistirDoPedido", true);
            Animacaoliente1.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente1.GetComponent<Animator>().SetBool("Walking", true);
            cliente1Desistiu = true;
            DeusExMachina.pedido1Completo = true;
        }
        #endregion
        #region Ativar Cliente2
        if (tempoElapsadoCliente1 < 40 || !DeusExMachina.pedido1Completo)
        {
            tempoElapsadoCliente2 = 0;
        }
        tempoElapsadoCliente2 += Time.deltaTime;
        if (tempoElapsadoCliente2 >= 2 && tempoElapsadoCliente2 < 13)
        {
            cliente2.GetComponent<Animator>().SetBool("Existo", true);
            Animacaoliente2.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente2 > 13 && tempoElapsadoCliente2 < 15)
        {
            Animacaoliente2.GetComponent<Animator>().SetBool("Walking", false);
        }
        if (tempoElapsadoCliente2 > 15 && tempoElapsadoCliente2 < 18)
        {
            cliente2.GetComponent<Animator>().SetBool("FoiAtendido", true);
            Animacaoliente2.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente2 >= 19 && tempoElapsadoCliente2 <= 30)
        {
            Animacaoliente2.GetComponent<Animator>().SetBool("Walking", false);
            Animacaoliente2.GetComponent<Animator>().SetBool("Sentado", true);
        }
        if (tempoElapsadoCliente2 >= 30)
        {
            cliente2.GetComponent<Animator>().SetBool("Demorando", true);
        }
        if (DeusExMachina.pedido2Completo)
        {
            cliente2.GetComponent<Animator>().SetBool("PedidoEntregue", true);
            Animacaoliente2.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente2.GetComponent<Animator>().SetBool("Walking", true);
            tempoElapsadoCliente2 = 40;
        }
        if (tempoElapsadoCliente2 >= 40 && !DeusExMachina.pedido2Completo)
        {
            cliente2.GetComponent<Animator>().SetBool("DesistirDoPedido", true);
            Animacaoliente2.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente2.GetComponent<Animator>().SetBool("Walking", true);
            cliente2Desistiu = true;
            DeusExMachina.pedido2Completo = true;
        }
        #endregion
        #region Ativar Cliente3
        if (tempoElapsadoCliente2 < 40 || !DeusExMachina.pedido2Completo)
        {
            tempoElapsadoCliente3 = 0;
        }
        tempoElapsadoCliente3 += Time.deltaTime;
        if (tempoElapsadoCliente3 >= 2 && tempoElapsadoCliente3 < 13)
        {
            cliente3.GetComponent<Animator>().SetBool("Existo", true);
            Animacaoliente3.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente3 > 13 && tempoElapsadoCliente3 < 15)
        {
            Animacaoliente3.GetComponent<Animator>().SetBool("Walking", false);
        }
        if (tempoElapsadoCliente3 > 15 && tempoElapsadoCliente3 < 18)
        {
            cliente3.GetComponent<Animator>().SetBool("FoiAtendido", true);
            Animacaoliente3.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente3 >= 19 && tempoElapsadoCliente3 <= 30)
        {
            Animacaoliente3.GetComponent<Animator>().SetBool("Walking", false);
            Animacaoliente3.GetComponent<Animator>().SetBool("Sentado", true);
        }
        if (tempoElapsadoCliente3 >= 30)
        {
            cliente3.GetComponent<Animator>().SetBool("Demorando", true);
        }
        if (DeusExMachina.pedido3Completo)
        {
            cliente3.GetComponent<Animator>().SetBool("PedidoEntregue", true);
            Animacaoliente3.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente3.GetComponent<Animator>().SetBool("Walking", true);
            tempoElapsadoCliente3 = 40;
        }
        if (tempoElapsadoCliente3 >= 40 && !DeusExMachina.pedido3Completo)
        {
            cliente3.GetComponent<Animator>().SetBool("DesistirDoPedido", true);
            Animacaoliente3.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente3.GetComponent<Animator>().SetBool("Walking", true);
            cliente3Desistiu = true;
            DeusExMachina.pedido3Completo = true;
        }
        #endregion
        #region Ativar Cliente4
        if (tempoElapsadoCliente3 < 40 || !DeusExMachina.pedido3Completo)
        {
            tempoElapsadoCliente4 = 0;
        }
        tempoElapsadoCliente4 += Time.deltaTime;
        if (tempoElapsadoCliente4 >= 2 && tempoElapsadoCliente4 < 13)
        {
            cliente4.GetComponent<Animator>().SetBool("Existo", true);
            Animacaoliente4.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente4 > 13 && tempoElapsadoCliente4 < 15)
        {
            Animacaoliente4.GetComponent<Animator>().SetBool("Walking", false);
        }
        if (tempoElapsadoCliente4 > 15 && tempoElapsadoCliente4 < 18)
        {
            cliente4.GetComponent<Animator>().SetBool("FoiAtendido", true);
            Animacaoliente4.GetComponent<Animator>().SetBool("Walking", true);
        }
        if (tempoElapsadoCliente4 >= 19 && tempoElapsadoCliente4 <= 30)
        {
            Animacaoliente4.GetComponent<Animator>().SetBool("Walking", false);
            Animacaoliente4.GetComponent<Animator>().SetBool("Sentado", true);
        }
        if (tempoElapsadoCliente4 >= 30)
        {
            cliente4.GetComponent<Animator>().SetBool("Demorando", true);
        }
        if (DeusExMachina.pedido4Completo)
        {
            cliente4.GetComponent<Animator>().SetBool("PedidoEntregue", true);
            Animacaoliente4.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente4.GetComponent<Animator>().SetBool("Walking", true);
            tempoElapsadoCliente4 = 40;
        }
        if (tempoElapsadoCliente4 >= 40 && !DeusExMachina.pedido4Completo)
        {
            cliente4.GetComponent<Animator>().SetBool("DesistirDoPedido", true);
            Animacaoliente4.GetComponent<Animator>().SetBool("Sentado", false);
            Animacaoliente4.GetComponent<Animator>().SetBool("Walking", true);
            cliente4Desistiu = true;
        }
        #endregion
    }
    
}
