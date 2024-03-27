using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("KeyBinds")]
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode useKey = KeyCode.E;

    [Header("Variables")]
    [SerializeField] Rigidbody playerFisic;
    [SerializeField] Transform playerTransform;
    [SerializeField] float playerSpeed;
    [SerializeField] float movementSpeed;

    public Vector3 moveFront;
    public Vector3 moveRight;

    public Slider spdMultiplier;
    public TextMeshProUGUI sliderValue;

    private void Update()
    {
        sliderValue.text = "SPD multiplier: " + spdMultiplier.value.ToString("F0") + "X";
        movementSpeed = playerSpeed * spdMultiplier.value;
        Movment();
    }

    private void Movment() 
    {
        moveFront = playerTransform.forward;
        moveRight = playerTransform.right;

        if (Input.GetKey(forwardKey))
        {
            playerFisic.AddForce(moveFront.normalized * movementSpeed, ForceMode.Force);
        }
        if (Input.GetKey(backwardKey))
        {
            playerFisic.AddForce(-moveFront.normalized * movementSpeed, ForceMode.Force);
        }
        if (Input.GetKey(leftKey))
        {
            playerFisic.AddForce(-moveRight.normalized * movementSpeed, ForceMode.Force);
        }
        if (Input.GetKey(rightKey))
        {
            playerFisic.AddForce(moveRight.normalized * movementSpeed, ForceMode.Force);
        }
    }
}
