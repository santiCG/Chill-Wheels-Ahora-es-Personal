using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinkbull : MonoBehaviour
{
    [SerializeField] private AmountPizzas amountPizzas;
    public PlayerController playerController;

    public GameObject descripcion;
    public float nuevaVelocidad;
    private float costo = 2000f;


    void Start()
    {
        descripcion.SetActive(false);

    }
    public void OnMouseOver()
    {
        descripcion.SetActive(true);
        Debug.Log("Deteccion mouse");
    }

    public void OnMouseExit()
    {
        descripcion.SetActive(false);
        Debug.Log("salida mouse");
    }

    public void onClick()
    {

        if (amountPizzas.Pizzas >= costo)
        {

            if (playerController != null)
            {
                playerController.speed = nuevaVelocidad;
                Debug.Log("velocidad modificada a:" + nuevaVelocidad);

            }
        }

        else
        {
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }



    }
}
