using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FazedorDePedidos : NetworkBehaviour
{
    public PlayerController playerController;
     
    [Header("Order")]
    public NetworkVariable<int> itemPedido1 = new NetworkVariable<int>(0);
    public NetworkVariable<int> itemPedido2 = new NetworkVariable<int>(0);
    public NetworkVariable<int> itemPedido3 = new NetworkVariable<int>(0);

    public TextMeshProUGUI itemPedidoTxtCliente1;
    public TextMeshProUGUI itemPedidoTxtCliente2;
    public TextMeshProUGUI itemPedidoTxtCliente3;
    public TextMeshProUGUI itemPedidoTxtCliente4;

    public Collider cliente;

    public int[] pedidoDoCliente1;
    public int[] pedidoDoCliente2;
    public int[] pedidoDoCliente3;
    public int[] pedidoDoCliente4;

    bool esperandoParaPedir = false;
    float timer = 0f;

    [Header("ImagemDosPedidosCliente1")]
    public Image item1Pedido1;
    public Image item2Pedido1;
    public Image item3Pedido1;
    [Header("ImagemDosPedidosCliente2")]
    public Image item1Pedido2;
    public Image item2Pedido2;
    public Image item3Pedido2;
    [Header("ImagemDosPedidosCliente3")]
    public Image item1Pedido3;
    public Image item2Pedido3;
    public Image item3Pedido3;
    [Header("ImagemDosPedidosCliente4")]
    public Image item1Pedido4;
    public Image item2Pedido4;
    public Image item3Pedido4;

    [Header("SpriteDosPedidos")]
    public Sprite SpriteDeCarne; 
    public Sprite SpriteDeSalada; 
    public Sprite SpriteDeBebida;

    [Header("ConfirmaçãoDeEntrega")]
    public bool item1Pedido1foiEntregue;
    public bool item2Pedido1foiEntregue;
    public bool item3Pedido1foiEntregue;
    public bool pedido1Completo;

    [Header("AtivadorDeCliente")]
    public AtivadorDeCliente AtivadorDeCliente;

    //pedido2
    public bool item1Pedido2foiEntregue;
    public bool item2Pedido2foiEntregue;
    public bool item3Pedido2foiEntregue;
    public bool pedido2Completo;

    //pedido3
    public bool item1Pedido3foiEntregue;
    public bool item2Pedido3foiEntregue;
    public bool item3Pedido3foiEntregue;
    public bool pedido3Completo;

    //pedido4
    public bool item1Pedido4foiEntregue;
    public bool item2Pedido4foiEntregue;
    public bool item3Pedido4foiEntregue;
    public bool pedido4Completo;

    //verificadores
    public GameObject itemASerVerificado;
    public int verificarCarne = 1;

    public void VerificarPedidoSeguradoPeloPlayer()
    {
        if (!IsServer)
        {
            return;
        }
        //cliente1
        #region Controle De Pedido Cliente 1
        if (itemASerVerificado.tag == pedidoDoCliente1[0].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
        {
            if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
            {
                item1Pedido1foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
            else if (itemASerVerificado.tag != verificarCarne.ToString())
            {
                item1Pedido1foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
        }

        if (pedidoDoCliente1[1] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente1[1].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item2Pedido1foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item2Pedido1foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }

            }
        }
        else if (pedidoDoCliente1[1] == 0)
        {
            item2Pedido1foiEntregue = true;
        }
        //*************
        if (pedidoDoCliente1[2] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente1[2].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item3Pedido1foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item3Pedido1foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
            }
        }
        else if (pedidoDoCliente1[2] == 0)
        {
            item3Pedido1foiEntregue = true;
        }
        //************
        if (item1Pedido1foiEntregue && item2Pedido1foiEntregue && item3Pedido1foiEntregue)
        {
            pedido1Completo = true;
        }
        #endregion
        //cliente2
        #region Controle De Pedido Cliente 2
        if (itemASerVerificado.tag == pedidoDoCliente2[0].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
        {
            if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
            {
                item1Pedido2foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
            else if (itemASerVerificado.tag != verificarCarne.ToString())
            {
                item1Pedido2foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
        }

        if (pedidoDoCliente2[1] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente2[1].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item2Pedido2foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item2Pedido2foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }

            }
        }
        else if (pedidoDoCliente2[1] == 0)
        {
            item2Pedido2foiEntregue = true;
        }
        //*************
        if (pedidoDoCliente1[2] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente2[2].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item3Pedido2foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item3Pedido2foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
            }
        }
        else if (pedidoDoCliente2[2] == 0)
        {
            item3Pedido2foiEntregue = true;
        }
        //************
        if (item1Pedido2foiEntregue && item2Pedido2foiEntregue && item3Pedido2foiEntregue)
        {
            pedido2Completo = true;
        }
        #endregion
        //cliente3
        #region Controle De Pedido Cliente 3
        if (itemASerVerificado.tag == pedidoDoCliente3[0].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
        {
            if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
            {
                item1Pedido3foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
            else if (itemASerVerificado.tag != verificarCarne.ToString())
            {
                item1Pedido3foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
        }

        if (pedidoDoCliente3[1] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente3[1].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item2Pedido3foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item2Pedido3foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }

            }
        }
        else if (pedidoDoCliente3[1] == 0)
        {
            item2Pedido3foiEntregue = true;
        }
        //*************
        if (pedidoDoCliente3[2] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente3[2].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item3Pedido3foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item3Pedido3foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
            }
        }
        else if (pedidoDoCliente3[2] == 0)
        {
            item3Pedido3foiEntregue = true;
        }
        //************
        if (item1Pedido3foiEntregue && item2Pedido3foiEntregue && item3Pedido3foiEntregue)
        {
            pedido3Completo = true;
        }
        #endregion
        //cliente4
        #region Controle De Pedido Cliente 4
        if (itemASerVerificado.tag == pedidoDoCliente4[0].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
        {
            if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
            {
                item1Pedido4foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
            else if (itemASerVerificado.tag != verificarCarne.ToString())
            {
                item1Pedido4foiEntregue = true;
                playerController.DespawnServerRpc();
                playerController.ParaDeCarregar();
            }
        }

        if (pedidoDoCliente4[1] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente4[1].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item2Pedido4foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item2Pedido4foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }

            }
        }
        else if (pedidoDoCliente4[1] == 0)
        {
            item2Pedido4foiEntregue = true;
        }
        //*************
        if (pedidoDoCliente1[2] != 0)
        {
            if (itemASerVerificado.tag == pedidoDoCliente4[2].ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiProcessado)
            {
                if (itemASerVerificado.tag == verificarCarne.ToString() && itemASerVerificado.GetComponent<FoodProcessing>().foiCozido)
                {
                    item3Pedido4foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
                else if (itemASerVerificado.tag != verificarCarne.ToString())
                {
                    item3Pedido4foiEntregue = true;
                    playerController.DespawnServerRpc();
                    playerController.ParaDeCarregar();
                }
            }
        }
        else if (pedidoDoCliente4[2] == 0)
        {
            item3Pedido4foiEntregue = true;
        }
        //************
        if (item1Pedido4foiEntregue && item2Pedido4foiEntregue && item3Pedido4foiEntregue)
        {
            pedido4Completo = true;
        }
        #endregion
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cliente"))
        {
            cliente = other;

            if (IsServer)
            {
                OrderSelector();
            }
        }

        if (other.gameObject.CompareTag("Player"))
        {
            try
            {
                itemASerVerificado = other.gameObject.GetComponentInChildren<FoodProcessing>().gameObject;
                playerController = other.gameObject.GetComponent<PlayerController>();
            }
            catch (System.Exception)
            {
                Debug.Log("não esta segurando nada");
            }
        }
    }

    public void OrderSelector()
    {
        //tamanho de pedido aleatorio
        int tamanhoPedido = 1/*Random.Range(1, 2)*/;
        Debug.Log("tamanho do pedido " + tamanhoPedido);

        for (int i = 0; i < tamanhoPedido; i++)
        {
            int randomNumber = Random.Range(1, 4);
            //cozido = 1
            //salada = 2
            //bebida = 3

            switch (i)
            {
                case 0:
                    itemPedido1.Value = randomNumber;
                    break;
                case 1:
                    itemPedido2.Value = randomNumber;
                    break;
                case 2:
                    itemPedido3.Value = randomNumber;
                    
                    
                    break;
            }
        }

        esperandoParaPedir = true;
    }
    [ServerRpc]
    public void VitoriaServerRpc() 
    {
        if (!IsServer)
        {
            return;
        }
        if (pedido1Completo && pedido2Completo && pedido3Completo)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("CenaDeVitoria", UnityEngine.SceneManagement.LoadSceneMode.Single);
            //NetworkManager.Singleton.Shutdown();
        }
    }
    private void Update()
    {
        VitoriaServerRpc();

        if (esperandoParaPedir & IsServer)
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                esperandoParaPedir = false;
                timer = 0f;
                OrderSelectorClientRpc();
            }
        }
        
    }

    [ClientRpc]
    public void OrderSelectorClientRpc()
    {
        if (cliente.name == "Cliente1")
        {
            //pedidoDoCliente1[0] = itemPedido1.Value;
            //pedidoDoCliente1[1] = itemPedido2.Value;
            //pedidoDoCliente1[2] = itemPedido3.Value;
            pedidoDoCliente1[0] = 3;
            pedidoDoCliente1[1] = 0;
            pedidoDoCliente1[2] = 0;

            //ativar imagem aqui no lugar de setar texto
            //itemPedidoTxtCliente1.text = pedidoDoCliente1[0].ToString();
            //***************************
            switch (pedidoDoCliente1[0])
            {
                case 1:
                    item1Pedido1.GetComponent<Image>().sprite = SpriteDeCarne;
                    break;

                case 2:
                    item1Pedido1.GetComponent<Image>().sprite = SpriteDeSalada;
                    break;
                case 3:
                    item1Pedido1.GetComponent<Image>().sprite = SpriteDeBebida;
                    break;
            }
            //***************************

            if (pedidoDoCliente1[1] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente1.text += " " + pedidoDoCliente1[1].ToString();
                switch (pedidoDoCliente1[1])
                {
                    case 1:
                        item2Pedido1.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item2Pedido1.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item2Pedido1.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
            }
            if (pedidoDoCliente1[2] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente1.text += " " + pedidoDoCliente1[2].ToString();
                switch (pedidoDoCliente1[2])
                {
                    case 1:
                        item3Pedido1.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item3Pedido1.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item3Pedido1.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
            }
        }

        else if (cliente.name == "Cliente2")
        {
            //pedidoDoCliente2[0] = itemPedido1.Value;
            //pedidoDoCliente2[1] = itemPedido2.Value;
            //pedidoDoCliente2[2] = itemPedido3.Value;
            pedidoDoCliente2[0] = 1;
            pedidoDoCliente2[1] = 0;
            pedidoDoCliente2[2] = 0;

            //ativar imagem aqui no lugar de setar texto
            //itemPedidoTxtCliente2.text = pedidoDoCliente2[0].ToString();
            //***************************
            switch (pedidoDoCliente2[0])
            {
                case 1:
                    item1Pedido2.GetComponent<Image>().sprite = SpriteDeCarne;
                    break;

                case 2:
                    item1Pedido2.GetComponent<Image>().sprite = SpriteDeSalada;
                    break;
                case 3:
                    item1Pedido2.GetComponent<Image>().sprite = SpriteDeBebida;
                    break;
            }
            //***************************


            if (pedidoDoCliente2[1] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente2.text += " " + pedidoDoCliente2[1].ToString();
                //***************************
                switch (pedidoDoCliente2[1])
                {
                    case 1:
                        item2Pedido2.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item2Pedido2.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item2Pedido2.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
                //***************************
            }
            if (pedidoDoCliente2[2] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente2.text += " " + pedidoDoCliente2[2].ToString();
                //***************************
                switch (pedidoDoCliente2[2])
                {
                    case 1:
                        item3Pedido2.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item3Pedido2.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item3Pedido2.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
                //***************************
            }
        }
        else if (cliente.name == "Cliente3")
        {
            //pedidoDoCliente3[0] = itemPedido1.Value;
            //pedidoDoCliente3[1] = itemPedido2.Value;
            //pedidoDoCliente3[2] = itemPedido3.Value;
            pedidoDoCliente3[0] = 2;
            pedidoDoCliente3[1] = 0;
            pedidoDoCliente3[2] = 0;

            //ativar imagem aqui no lugar de setar texto
            //itemPedidoTxtCliente3.text = pedidoDoCliente3[0].ToString();
            //***************************
            switch (pedidoDoCliente3[0])
            {
                case 1:
                    item1Pedido3.GetComponent<Image>().sprite = SpriteDeCarne;
                    break;

                case 2:
                    item1Pedido3.GetComponent<Image>().sprite = SpriteDeSalada;
                    break;
                case 3:
                    item1Pedido3.GetComponent<Image>().sprite = SpriteDeBebida;
                    break;
            }
            //***************************

            if (pedidoDoCliente3[1] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente3.text += " " + pedidoDoCliente3[1].ToString();
                //***************************
                switch (pedidoDoCliente3[1])
                {
                    case 1:
                        item2Pedido3.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item2Pedido3.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item2Pedido3.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
                //***************************
            }
            if (pedidoDoCliente3[2] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente3.text += " " + pedidoDoCliente3[2].ToString();
                switch (pedidoDoCliente3[2])
                {
                    case 1:
                        item3Pedido3.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item3Pedido3.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item3Pedido3.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
                //***************************
            }
        }
        else if (cliente.name == "Cliente4")
        {
            pedidoDoCliente4[0] = itemPedido1.Value;
            pedidoDoCliente4[1] = itemPedido2.Value;
            pedidoDoCliente4[2] = itemPedido3.Value;

            //ativar imagem aqui no lugar de setar texto
            //itemPedidoTxtCliente4.text = pedidoDoCliente4[0].ToString();
            switch (pedidoDoCliente4[0])
            {
                case 1:
                    item1Pedido4.GetComponent<Image>().sprite = SpriteDeCarne;
                    break;

                case 2:
                    item1Pedido4.GetComponent<Image>().sprite = SpriteDeSalada;
                    break;
                case 3:
                    item1Pedido4.GetComponent<Image>().sprite = SpriteDeBebida;
                    break;
            }
            //***************************

            if (pedidoDoCliente4[1] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente4.text += " " + pedidoDoCliente4[1].ToString();
                switch (pedidoDoCliente4[1])
                {
                    case 1:
                        item2Pedido4.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item2Pedido4.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item2Pedido4.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
                //***************************
            }
            if (pedidoDoCliente4[2] != 0)
            {
                //ativar imagem aqui no lugar de setar texto
                //itemPedidoTxtCliente4.text += " " + pedidoDoCliente4[2].ToString();
                switch (pedidoDoCliente4[2])
                {
                    case 1:
                        item3Pedido4.GetComponent<Image>().sprite = SpriteDeCarne;
                        break;

                    case 2:
                        item3Pedido4.GetComponent<Image>().sprite = SpriteDeSalada;
                        break;
                    case 3:
                        item3Pedido4.GetComponent<Image>().sprite = SpriteDeBebida;
                        break;
                }
                //***************************
            }
        }
    }
}
