using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject player;
    [SerializeField] GameObject item;
    [SerializeField] Rigidbody itemRB;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (item.transform.parent != null)
            {
                //item.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z +3).normalized;
                item.transform.SetParent(null);
                //item.transform.rotation = Quaternion.identity;
                itemRB.isKinematic = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            itemRB.isKinematic = true;
            item.transform.position = new Vector3(0,2,0);
            item.transform.rotation = Quaternion.identity;
            item.transform.SetParent(collision.collider.transform, false);
            return;
        }
    }
}
