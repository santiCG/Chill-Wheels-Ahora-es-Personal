using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guepardex : MonoBehaviour
{

    [SerializeField] private AmountPizzas amountPizzas;
    [SerializeField] private Piz_x_seg pizzasPorSegundo;

    public PlayerController playerController;

    public GameObject descripcion;
    //public AmountPizzas amountPizzas;

    private float costo = 10000f;
    //public GameObject Boton_normal;
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
                if (amountPizzas != null && pizzasPorSegundo != null)
                {
                    // Obtener la cantidad de pizzas por segundo
                    float pizzasPorSegundoValue = pizzasPorSegundo.pizzas_seg;

                    // Calcular la cantidad total de pizzas para 30 minutos
                    float cantidadTotalPizzas = pizzasPorSegundoValue * 1800;

                    // Agregar la cantidad total de pizzas al contador
                    amountPizzas.SumarPizzas(cantidadTotalPizzas);

                    Debug.Log("Se agregaron " + cantidadTotalPizzas + " pizzas al contador.");

                }
            }
        }

        else
        {
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }


    }
}

