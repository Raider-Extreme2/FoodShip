using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FoodProcessing : NetworkBehaviour
{
    [Header("PlayerFinder")]
    public LayerMask playerLayerMask;
    Ray playerScanner;
    GameObject playerToParent;

    [Header("Item To Render")]
    [SerializeField] Transform itemBase;
    [SerializeField] Transform itemProcessado;
    [SerializeField] Transform itemCozido;

    [Header("Processos aplicaveis")]
    public bool processavel;
    public bool cozivel;

    [Header("Ações executadas")]
    public bool foiProcessado;
    public bool foiCozido;

    private void Start()
    {
        playerScanner = new Ray(transform.position, Vector3.down);
        processavel = true;
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            if (Physics.Raycast(playerScanner, out RaycastHit hit, 2f, playerLayerMask))
            {
                playerToParent = hit.collider.GetComponent<NetworkObject>().gameObject;
                transform.position = new Vector3(0, 1.5f, 0.4f);
                transform.SetParent(playerToParent.transform, false);
                //Debug.Log(hit.transform.gameObject.name);
            }
        }

        Debug.DrawRay(transform.position, Vector3.down * 5f, Color.red);
    }

    public void AtualizarObjetoParaProcessado()
    {
        foiProcessado = true;
        if (processavel && foiProcessado)
        {
            itemBase.gameObject.SetActive(false);
            itemProcessado.gameObject.SetActive(true);
        }

    }
    public void AtualizarObjetoParaCozido()
    {
        foiCozido = true;
        if (cozivel && foiProcessado && foiCozido)
        {
            itemBase.gameObject.SetActive(false);
            itemProcessado.gameObject.SetActive(false);
            itemCozido.gameObject.SetActive(true);
        }
    }
}
