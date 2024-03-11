using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iman_Pizzas : MonoBehaviour
{
    public GameObject descripcion;
    [SerializeField] private AmountPizzas amountPizzas;

    public GameObject jugador;
    public PlayerController playerController;
    private BoxCollider2D boxCollider;

    private float costo = 1f;
    //public GameObject Boton_normal;
    void Start()
    {
        descripcion.SetActive(false);

        if (jugador != null)
        {
            boxCollider = jugador.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                // Desactivar el BoxCollider2D del jugador al inicio
                boxCollider.enabled = false;
            }
            else
            {
                Debug.LogWarning("BoxCollider2D no encontrado en el jugador.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject del jugador no asignado en iman_pizzas.");
        }

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
            if (jugador != null && playerController != null && boxCollider != null)
            {
                // Activar el BoxCollider2D del jugador al hacer clic
                boxCollider.enabled = true;
                Debug.Log("BoxCollider2D activado en el jugador.");
            }
            else
            {
                Debug.LogWarning("GameObject del jugador, PlayerController o BoxCollider2D no asignado en iman_pizzas.");
            }
        }

        else
        {
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }
    }


}

