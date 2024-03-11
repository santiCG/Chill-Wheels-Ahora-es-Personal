using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon_Mario : MonoBehaviour
{
    public PizzaCollectible pizzaCollectible1; // Referencia al primer objeto PizzaCollectible
    public PizzaCollectible pizzaCollectible2; // Referencia al segundo objeto PizzaCollectible
    [SerializeField] private AmountPizzas amountPizzas;

    private float duracionEfecto = 60f; // Duración del efecto en segundos
    private bool efectoActivo = false; // Indica si el efecto está activo

    public GameObject descripcion;
    private float costo = 1f;

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
            if (!efectoActivo && pizzaCollectible1 != null && pizzaCollectible2 != null)
            {
                StartCoroutine(TriplePizzasEffect(pizzaCollectible1)); // Aplicar efecto al primer objeto
                StartCoroutine(TriplePizzasEffect(pizzaCollectible2)); // Aplicar efecto al segundo objeto
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
    IEnumerator TriplePizzasEffect(PizzaCollectible pizzaCollectible)
    {
        efectoActivo = true;

        efectoActivo = true;

        // Guardar el valor original de cantidad de pizzas
        float valorOriginal = pizzaCollectible.cantidadPizzas;

        // Triplicar el valor de cantidad de pizzas
        pizzaCollectible.cantidadPizzas *= 3;

        // Esperar la duración del efecto
        yield return new WaitForSeconds(duracionEfecto);

        // Restaurar el valor original de cantidad de pizzas
        pizzaCollectible.cantidadPizzas = valorOriginal;

        efectoActivo = false;
    }
}
