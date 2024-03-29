using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Iman_Pizzas : MonoBehaviour
{
    //public GameObject descripcion;
    [SerializeField] private AmountPizzas amountPizzas;

    [SerializeField] private TextMeshProUGUI costoText;
    [SerializeField] private GameObject descripcionContainer; // Nuevo GameObject para el contenedor de la descripción
    [SerializeField] private TextMeshProUGUI descripcionText; // Nuevo TextMeshProUGUI para la descripción
    [SerializeField] private Image backgroundImage;

    public GameObject jugador;
    public PlayerController playerController;
    private BoxCollider2D boxCollider;

    public float costo = 575f;

    private int nivel = 0;


    //public GameObject Boton_normal;
    void Start()
    {
        descripcionContainer.SetActive(false);
        ActualizarTextoCosto();
        ActualizarTextoDescripcion();
        ActualizarColorFondo();

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

    void Update()
    {
        if(nivel==1)
        {
            backgroundImage.color = Color.red;
        }


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
        Debug.Log("aqui va la accion de click");

        if (amountPizzas.Pizzas >= costo && nivel == 0)
        {
            nivel++;
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
        descripcionText.text = "Atrae pizzas cercanas! PERMANENTEMENTE"; // Actualiza el texto de la descripción
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
