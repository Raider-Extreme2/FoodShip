using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("KeyBinds")]
    public KeyCode useKey = KeyCode.E;

    [Header("Variables")]
    [SerializeField] float playerSpeed;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movmentDirection = new Vector3(horizontalInput, 0, verticalInput);
        movmentDirection.Normalize();

        transform.Translate(movmentDirection * movementSpeed * Time.deltaTime, Space.World);

        if (movmentDirection != Vector3.zero)
        {
            Quaternion rotateThisWay = Quaternion.LookRotation(movmentDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateThisWay, rotationSpeed * Time.deltaTime);
        }
    }
}
