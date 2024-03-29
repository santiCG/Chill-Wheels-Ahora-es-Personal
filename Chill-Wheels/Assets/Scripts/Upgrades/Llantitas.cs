using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Llantitas : MonoBehaviour
{
    [SerializeField] private Piz_x_seg pizzas_x_seg;
    [SerializeField] private AmountPizzas amountPizzas;

    [SerializeField] private TextMeshProUGUI costoText; // Usamos TextMeshProUGUI en lugar de Text
    [SerializeField] private TextMeshProUGUI nivelText; // Nuevo TextMeshProUGUI para el nivel
    [SerializeField] private GameObject descripcionContainer; // Nuevo GameObject para el contenedor de la descripción
    [SerializeField] private TextMeshProUGUI descripcionText; // Nuevo TextMeshProUGUI para la descripción
    [SerializeField] private Image backgroundImage;

    // Produccion 
    private float produccion = 15f;

    //Costo
    private int nivel = 1;
    public float costo = 299f;


    void Start()
    {
        descripcionContainer.SetActive(false); // Desactiva el contenedor de la descripción al inicio
        ActualizarTextoCosto();
        ActualizarTextoNivel();
        ActualizarTextoDescripcion();
        ActualizarColorFondo();

    }

    void Update()
    {
        ActualizarColorFondo(); // Llama a la función de actualización de color de fondo en cada fotograma
    }

    // Update is called once per frame
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
            pizzas_x_seg.AumentarPiz_Seg(produccion);

            produccion += Mathf.Round(Mathf.Sqrt(produccion));

            amountPizzas.Pizzas -= costo;

            costo = Mathf.Round(260 * Mathf.Pow(1.15f, nivel));

            nivel++;

            ActualizarTextoCosto();
            ActualizarTextoNivel();
            ActualizarTextoDescripcion();
            ActualizarColorFondo();

        }
        else
        {
            Debug.Log("No te alcanza");
            backgroundImage.color = Color.red;
        }
    }

    private void ActualizarTextoCosto()
    {
        costoText.text = "Costo: " + costo.ToString() + " P"; // Actualiza el texto con el nuevo costo
    }

    private void ActualizarTextoNivel()
    {
        nivelText.text = nivel.ToString(); // Actualiza el texto con el nuevo nivel
    }

    private void ActualizarTextoDescripcion()
    {
        descripcionText.text = "Rueda suavemente!\nProducción: + " + produccion.ToString() + "p/s"; // Actualiza el texto de la descripción
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
