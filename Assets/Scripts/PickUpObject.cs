using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject itemSegurado;
    [SerializeField] Rigidbody itemRB;
    public Transform localOrigem;
    public PlayerController PlayerController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Disherda();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = localOrigem.transform.position;
        }
    }
    public void Disherda()
    {
        //se tiver um pai
        if (itemSegurado.transform.parent != null)
        {
            // desliga o parentesco
            itemSegurado.transform.SetParent(null);
            itemRB.isKinematic = false;
            PlayerController.segurandoUmItem = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        itemSegurado = transform.gameObject;
        if (collision.collider.tag == "Player")
        {
            //coleta o item e coloca como filho do player
            itemRB.isKinematic = true;
            //vector 3 baseado na posição de objeto do player
            itemSegurado.transform.position = new Vector3(0,2,0);
            //quaternion baseado na rotação do player
            itemSegurado.transform.rotation = Quaternion.identity;
            //objeto segurado não colide com outros objetos
            itemSegurado.transform.SetParent(collision.collider.transform, false);
            return;
        }
    }
}
