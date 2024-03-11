using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harina_Pan : MonoBehaviour
{
    [SerializeField] private AmountPizzas amountPizzas;
    [SerializeField] private Piz_x_seg pizzasPorSegundo;
    public PlayerController playerController;

    private float multiplicadorInicial = 2f; // Multiplicador inicial para la cantidad de pizzas por segundo
    private float duracionMultiplicador = 5f; // Duración del multiplicador en segundos


    public GameObject descripcion;

    private float costo = 5000f;

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

                    //aqui lo quiero multiplicar por dos, despues de un minuto, que vuelva a la normalidad

                    StartCoroutine(MultiplicarPizzasPorSegundo(pizzasPorSegundoValue));


                }
            }
        }

        else
        {
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }


    }

    IEnumerator MultiplicarPizzasPorSegundo(float valorInicial)
    {
        pizzasPorSegundo.pizzas_seg *= multiplicadorInicial; // Multiplicar por el valor inicial

        yield return new WaitForSeconds(duracionMultiplicador); // Esperar el tiempo especificado

        pizzasPorSegundo.pizzas_seg = valorInicial; // Volver al valor inicial
    }
}
