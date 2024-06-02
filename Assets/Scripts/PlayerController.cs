using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

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

    [Header("Animator Variables")]
    [SerializeField] Animator playerAnimator;

    [Header("Pick Up Variables")]
    public bool segurandoUmItem;
    [SerializeField] Transform carneMonstroPrefab;
    [SerializeField] Transform saladaMonstroPrefab;
    [SerializeField] Transform bebidaMonstroPrefab;
    Transform itemSpawnado;
    public Transform placeToSpawnItem;

    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        playerVision = new Ray(transform.position, transform.forward);
        Movment();
        PegarItem();
        AnimationTest();
        ForceInteraction();
    }

    private void Movment()
    {
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
                    /*itemSpawnado = Instantiate(carneMonstroPrefab);
                    itemSpawnado.GetComponent<NetworkObject>().Spawn();*/

                    //SpawnLocalIngredient(itemSpawnado);

                    segurandoUmItem = true;
                    CarneSpawnerServerRpc();
                }
                if (hit.collider.gameObject.name == "CaixaCogumelo" && Input.GetKeyDown(useKey) && !segurandoUmItem)
                {
                    /*itemSpawnado = Instantiate(bebidaMonstroPrefab);
                    itemSpawnado.GetComponent<NetworkObject>().Spawn();*/

                    //SpawnLocalIngredient(itemSpawnado);

                    segurandoUmItem = true;
                    BebidaSpawnerServerRpc();
                }
                if (hit.collider.gameObject.name == "CaixaRepolho" && Input.GetKeyDown(useKey) && !segurandoUmItem)
                {
                    /*itemSpawnado = Instantiate(saladaMonstroPrefab);
                    itemSpawnado.GetComponent<NetworkObject>().Spawn();*/

                    //SpawnLocalIngredient(itemSpawnado);

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

    void SpawnLocalIngredient(Transform itemPraSpawnar)
    {
        //Instantiate(itemPraSpawnar);
        //objetoNetwork = itemPraSpawnar.GetComponent<NetworkObject>();
        //objetoNetwork.Spawn();
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
        //itemSpawnado.SetParent(placeToSpawnItem, false);
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


    public void AnimationTest()
    {
        //if (Input.GetKey(KeyCode.Y))
        //{
        //    playerAnimator.SetBool("Carregando", true);
        //}
        //else
        //{
        //    playerAnimator.SetBool("Carregando", false);
        //}
        //if (Input.GetKey(KeyCode.U))
        //{
        //    playerAnimator.SetBool("Andando", true);
        //}
        //else
        //{
        //    playerAnimator.SetBool("Andando", false);
        //}
        //if (Input.GetKey(KeyCode.I))
        //{
        //    playerAnimator.SetBool("Interagindo", true);
        //}
        //else
        //{
        //    playerAnimator.SetBool("Interagindo", false);
        //}
    }

    public void ForceInteraction()
    {
        if (Input.GetKeyDown(KeyCode.C) && segurandoUmItem)
        {
            ProcessarServerRpc();
        }
        if (Input.GetKeyDown(KeyCode.B) && segurandoUmItem)
        {
            CozinharServerRpc();
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
}
