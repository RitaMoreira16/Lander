using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{

    [SerializeField]
    float maxRelativeVelocity = 10f;
    [SerializeField]
    float maxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;
    [SerializeField]
    float torqueForce = 15f;

    [SerializeField]
    float fuel = 500f;
    [SerializeField]
    float fuelForca = 10f;
    [SerializeField]
    float fuelTorque = 5f;

    [SerializeField] TMP_Text txtFuelValor;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (fuel > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(thrustForce * transform.up * Time.deltaTime);
                fuel -= fuelForca * Time.deltaTime;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (fuel > 0)
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                fuel -= fuelTorque * Time.deltaTime;
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (fuel > 0)
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                fuel -= fuelTorque * Time.deltaTime;
            }

        }

        txtFuelValor.text = Mathf.RoundToInt(fuel).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Plataforma")
        {
            //bati na plataforma
            Debug.Log("Aterrei na plataforma");
            //Debug.Log(collision.relativeVelocity); //para verificar
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("Mas rebentei!");
            }
        }
        else
        {
            Debug.Log("Bati na lua... explodi!");
        }
    }
}
