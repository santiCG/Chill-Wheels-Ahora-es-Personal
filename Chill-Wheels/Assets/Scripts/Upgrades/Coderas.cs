using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coderas : MonoBehaviour
{
    [SerializeField] private Piz_x_seg pizzas_x_seg;
    [SerializeField] private AmountPizzas amountPizzas;

    [SerializeField] private TextMeshProUGUI costoText; // Usamos TextMeshProUGUI en lugar de Text
    [SerializeField] private TextMeshProUGUI nivelText; // Nuevo TextMeshProUGUI para el nivel
    [SerializeField] private GameObject descripcionContainer; // Nuevo GameObject para el contenedor de la descripci�n
    [SerializeField] private TextMeshProUGUI descripcionText; // Nuevo TextMeshProUGUI para la descripci�n
    [SerializeField] private Image backgroundImage;

    // Produccion 
    private float produccion = 35f;

    //Costo
    private int nivel = 1;
    public float costo = 805f;


    void Start()
    {
        descripcionContainer.SetActive(false); // Desactiva el contenedor de la descripci�n al inicio
        ActualizarTextoCosto();
        ActualizarTextoNivel();
        ActualizarTextoDescripcion();
        ActualizarColorFondo();

    }

    void Update()
    {
        ActualizarColorFondo(); // Llama a la funci�n de actualizaci�n de color de fondo en cada fotograma
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

            produccion += Mathf.Round(Mathf.Sqrt(produccion)); //EL ROUD ES NUEVO AQUI, VER FUNCIONALIDAD

            amountPizzas.Pizzas -= costo;

            costo = Mathf.Round(700 * Mathf.Pow(1.15f, nivel));

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
        descripcionText.text = "porque tus codos tambi�n merecen amor y protecci�n!\nProducci�n: + " + produccion.ToString() + "p/s"; // Actualiza el texto de la descripci�n
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
