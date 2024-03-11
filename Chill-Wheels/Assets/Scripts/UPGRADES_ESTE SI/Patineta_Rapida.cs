using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Patineta_Rapida : MonoBehaviour
{
    [SerializeField] private AmountPizzas amountPizzas;

    public PlayerController playerController;
    public float nuevaVelocidad;
    public float duracionCambioVelocidad = 5f;
    public float velocidadOriginal;




    public GameObject descripcion;
    private float costo = 345f;

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
                //playerController.speed = nuevaVelocidad;
                //Debug.Log("velocidad modificada a:" + nuevaVelocidad);
                StartCoroutine(CambiarVelocidadTemporal());
            }
        }

        else 
        {
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }

       
        Debug.Log("aqui va la accion de click");


    }

    IEnumerator CambiarVelocidadTemporal()
    {
        velocidadOriginal = playerController.speed; // Guardar la velocidad original

        playerController.speed = nuevaVelocidad; // Cambiar a la nueva velocidad

        yield return new WaitForSeconds(duracionCambioVelocidad); // Esperar el tiempo especificado

        playerController.speed = velocidadOriginal; // Restaurar la velocidad original
    }
}
