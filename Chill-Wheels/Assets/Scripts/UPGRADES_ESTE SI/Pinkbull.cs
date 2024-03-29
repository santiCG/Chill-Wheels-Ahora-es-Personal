using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pinkbull : MonoBehaviour
{
    [SerializeField] private AmountPizzas amountPizzas;
    public PlayerController playerController;

    [SerializeField] private TextMeshProUGUI costoText;
    [SerializeField] private GameObject descripcionContainer; // Nuevo GameObject para el contenedor de la descripción
    [SerializeField] private TextMeshProUGUI descripcionText; // Nuevo TextMeshProUGUI para la descripción
    [SerializeField] private Image backgroundImage;

    //public GameObject descripcion;
    public float nuevaVelocidad;
    public float costo = 2000f;


    void Start()
    {
        descripcionContainer.SetActive(false);
        ActualizarTextoCosto();
        ActualizarTextoDescripcion();
        ActualizarColorFondo();

    }

    void Update()
    {
        ActualizarColorFondo(); // Llama a la función de actualización de color de fondo en cada fotograma
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
                playerController.speed = nuevaVelocidad;
                Debug.Log("velocidad modificada a:" + nuevaVelocidad);

            }
        }

        else
        {
            backgroundImage.color = Color.red;
            Debug.Log("No tiene suficientes pizzas, necesarias: " + costo);
        }



    }

    private void ActualizarTextoCosto()
    {
        costoText.text = "Costo: " + costo.ToString() + " P"; // Actualiza el texto con el nuevo costo

    }

    private void ActualizarTextoDescripcion()
    {
        descripcionText.text = "Aumenta la velocidad de forma PERMANENTE"; // Actualiza el texto de la descripción
    }
    private void ActualizarColorFondo()
    {
        // Cambia el color de fondo de la imagen según la cantidad de pizzas
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
