using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Harina_Pan : MonoBehaviour
{
    [SerializeField] private AmountPizzas amountPizzas;
    [SerializeField] private Piz_x_seg pizzasPorSegundo;
    public PlayerController playerController;

    [SerializeField] private TextMeshProUGUI costoText;
    [SerializeField] private GameObject descripcionContainer; // Nuevo GameObject para el contenedor de la descripci�n
    [SerializeField] private TextMeshProUGUI descripcionText; // Nuevo TextMeshProUGUI para la descripci�n
    [SerializeField] private Image backgroundImage;

    private float multiplicadorInicial = 2f; // Multiplicador inicial para la cantidad de pizzas por segundo
    private float duracionMultiplicador = 5f; // Duraci�n del multiplicador en segundos


   // public GameObject descripcion;

    public float costo = 5000f;

    void Start()
    {
        descripcionContainer.SetActive(false);
        ActualizarTextoCosto();
        ActualizarTextoDescripcion();
        ActualizarColorFondo();

    }

    void Update()
    {
        ActualizarColorFondo(); // Llama a la funci�n de actualizaci�n de color de fondo en cada fotograma
    }

    public void OnMouseOver()
    {
        descripcionContainer.SetActive(true);
        descripcionText.gameObject.SetActive(true);
        Debug.Log("Deteccion mouse");
    }

    public void OnMouseExit()
    {
        descripcionContainer.SetActive(false);
        descripcionText.gameObject.SetActive(false);
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
            backgroundImage.color = Color.red;
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }


    }

    IEnumerator MultiplicarPizzasPorSegundo(float valorInicial)
    {
        pizzasPorSegundo.pizzas_seg *= multiplicadorInicial; // Multiplicar por el valor inicial

        yield return new WaitForSeconds(duracionMultiplicador); // Esperar el tiempo especificado

        pizzasPorSegundo.pizzas_seg = valorInicial; // Volver al valor inicial
    }

    private void ActualizarTextoCosto()
    {
        costoText.text = "Costo: " + costo.ToString() + " P"; // Actualiza el texto con el nuevo costo

    }

    private void ActualizarTextoDescripcion()
    {
        descripcionText.text = "Duplica las p/s por un minuto"; // Actualiza el texto de la descripci�n
    }
    private void ActualizarColorFondo()
    {
        // Cambia el color de fondo de la imagen seg�n la cantidad de pizzas
        if (amountPizzas.Pizzas >= costo)
        {
            // Cuando hay suficientes pizzas, el color de fondo vuelve a su estado original
            backgroundImage.color = Color.white; // Por ejemplo, cambia el color a blanco
        }
        else
        {
            // Cuando no hay suficientes pizzas, el color de fondo se establece en rojo
            backgroundImage.color = Color.red; // Por ejemplo, cambia el color a rojo
        }
    }
}
