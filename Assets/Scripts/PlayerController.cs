using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;

public class PlayerController : NetworkBehaviour
{
    [Header("KeyBinds")]
    public KeyCode useKey = KeyCode.E;

    [Header("Movment Variables")]
    [SerializeField] float playerSpeed;
    [SerializeField] float rotationSpeed;

    [Header("Raycast Variables")]
    Ray playerVision;
    public float maxDistance;
    public LayerMask interactibleObject;
    public LayerMask processingStation;
    public LayerMask tabuaDeCortar;
    public LayerMask CookPot;
    public LayerMask lixeira;
    public LayerMask entregas;

    [Header("Animator Variables")]
    [SerializeField] Animator playerAnimator;

    [Header("Pick Up Variables")]
    public bool segurandoUmItem;
    [SerializeField] Transform carneMonstroPrefab;
    [SerializeField] Transform saladaMonstroPrefab;
    [SerializeField] Transform bebidaMonstroPrefab;
    Transform itemSpawnado;
    public Transform placeToSpawnItem;

    [Header("Interagindo com Cenario")]
    public bool estaInteragindo;

    [Header("FazedorDePedidos")]
    public FazedorDePedidos DeusExMachina;
    public bool podeEntregar;

    [Header("SoundPlayer")]
    public AudioClip tabua;
    public AudioClip panela;
    public AudioClip maquinaDeSuco;
    public AudioClip lataDeLixo;
    public AudioSource radio;

    public override void OnNetworkSpawn()
    {
        transform.transform.position = new Vector3(Random.Range(-3, 3), 1, -6f);
        base.OnNetworkSpawn();
    }
    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        playerVision = new Ray(transform.position, transform.forward);
        Movment();
        PegarItem();
        ForceInteraction();
    }

    private void Movment()
    {
        if (estaInteragindo)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movmentDirection = new Vector3(horizontalInput, 0, verticalInput);
        movmentDirection.Normalize();

        transform.Translate(movmentDirection * playerSpeed * Time.deltaTime, Space.World);

        if (movmentDirection != Vector3.zero)
        {
            Quaternion rotateThisWay = Quaternion.LookRotation(movmentDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateThisWay, rotationSpeed * Time.deltaTime);
            if (!segurandoUmItem)
            {
                playerAnimator.SetBool("Andando", true);
            }
            else if (segurandoUmItem)
            {
                playerAnimator.SetBool("Carregando", true);
            }
            else
            {
                playerAnimator.SetBool("Carregando", false);
            }
        }
        else
        {
            playerAnimator.SetBool("Andando", false);
        }
    }

    public void PegarItem()
    {
        if (Physics.Raycast(playerVision, out RaycastHit hit, maxDistance, interactibleObject, QueryTriggerInteraction.Collide))
        {
            Debug.Log(hit.collider.gameObject.name + " foi atingido");
            if (hit.collider.gameObject.GetComponent<BoxItemSpawner>().interactible)
            {
                Debug.Log("a interação com " + hit.collider.gameObject.name + " é possivel");
                if (hit.collider.gameObject.name == "CaixaCarneCrua" && Input.GetKeyDown(useKey) && !segurandoUmItem)
                {
                    segurandoUmItem = true;
                    CarneSpawnerServerRpc();
                }
                if (hit.collider.gameObject.name == "CaixaCogumelo" && Input.GetKeyDown(useKey) && !segurandoUmItem)
                {
                    segurandoUmItem = true;
                    BebidaSpawnerServerRpc();
                }
                if (hit.collider.gameObject.name == "CaixaRepolho" && Input.GetKeyDown(useKey) && !segurandoUmItem)
                {
                    segurandoUmItem = true;
                    RepolhoSpawnerServerRpc();
                }
            }
            else
            {
                Debug.Log("a interação com " + hit.collider.gameObject.name + " não é possivel");
            }
        }
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);
    }

    [ServerRpc(RequireOwnership = false)]
    void CarneSpawnerServerRpc()
    {
        itemSpawnado = Instantiate
            (
            carneMonstroPrefab,
            new Vector3(placeToSpawnItem.transform.position.x, placeToSpawnItem.transform.position.y, placeToSpawnItem.transform.position.z),
            Quaternion.identity
            );
        itemSpawnado.GetComponent<NetworkObject>().Spawn();
    }

    [ServerRpc(RequireOwnership = false)]
    void BebidaSpawnerServerRpc()
    {
        itemSpawnado = Instantiate
            (
            bebidaMonstroPrefab,
            new Vector3(placeToSpawnItem.transform.position.x, placeToSpawnItem.transform.position.y, placeToSpawnItem.transform.position.z),
            Quaternion.identity
            );
        itemSpawnado.GetComponent<NetworkObject>().Spawn();
    }

    [ServerRpc(RequireOwnership = false)]
    void RepolhoSpawnerServerRpc()
    {
        itemSpawnado = Instantiate
            (
            saladaMonstroPrefab,
            new Vector3(placeToSpawnItem.transform.position.x, placeToSpawnItem.transform.position.y, placeToSpawnItem.transform.position.z),
            Quaternion.identity
            );
        itemSpawnado.GetComponent<NetworkObject>().Spawn();
    }
    public void ForceInteraction()
    {
        if (Physics.Raycast(playerVision, out RaycastHit hit, maxDistance, processingStation, QueryTriggerInteraction.Collide) && segurandoUmItem && Input.GetKeyDown(useKey))
        {
            radio.PlayOneShot(maquinaDeSuco);
            ProcessarServerRpc();
        }
        if (Physics.Raycast(playerVision, out RaycastHit hit2, maxDistance, tabuaDeCortar, QueryTriggerInteraction.Collide) && segurandoUmItem && Input.GetKeyDown(useKey))
        {
            radio.PlayOneShot(tabua);
            ProcessarServerRpc();
        }
        if (Physics.Raycast(playerVision, out RaycastHit hit3, maxDistance, CookPot, QueryTriggerInteraction.Collide) && segurandoUmItem && Input.GetKeyDown(useKey))
        {
            radio.PlayOneShot(panela);
            CozinharServerRpc();
        }
        if (Physics.Raycast(playerVision, out RaycastHit hit4, maxDistance, lixeira, QueryTriggerInteraction.Collide) && segurandoUmItem && Input.GetKeyDown(useKey))
        {
            radio.PlayOneShot(lataDeLixo);
            DespawnServerRpc();
            ParaDeCarregar();
        }

        if (podeEntregar && Input.GetKeyDown(useKey))
        {
            VerificarItemServerRpc();
            ParaDeCarregar();
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " foi colidido PELO PLAYER");
        if (other.gameObject.name == "FazedorDePedidos")
        {
            DeusExMachina = other.gameObject.GetComponent<FazedorDePedidos>();
            podeEntregar = true;
        }
       
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FazedorDePedidos")
        {
            podeEntregar = false;
        }
    }

    [ServerRpc]
    void ProcessarServerRpc()
    {
        ProcessarClientRpc();
    }

    [ClientRpc]
    void ProcessarClientRpc()
    {
        GetComponentInChildren<FoodProcessing>().AtualizarObjetoParaProcessado();
    }

    [ServerRpc]
    void CozinharServerRpc()
    {
        CozinharClientRpc();
    }

    [ClientRpc]
    void CozinharClientRpc()
    {
        GetComponentInChildren<FoodProcessing>().AtualizarObjetoParaCozido();
    }

    [ServerRpc(RequireOwnership = false)]
    public void DespawnServerRpc()
    {
        if (IsServer)
        {
            Destroy(itemSpawnado.GetComponent<NetworkObject>());
            itemSpawnado.GetComponent<NetworkObject>().Despawn();
        }
    }

    public void ParaDeCarregar() 
    {
        segurandoUmItem = false;
        playerAnimator.SetBool("Carregando", false);
    }

    [ServerRpc(RequireOwnership = false)]
    public void VerificarItemServerRpc()
    {
        if (IsServer)
        DeusExMachina.VerificarPedidoSeguradoPeloPlayer();
    }
}
