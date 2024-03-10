using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennis : MonoBehaviour
{
    [SerializeField] private Piz_x_seg pizzas_x_seg;
    [SerializeField] private AmountPizzas amountPizzas;

    // Produccion del horno
    private float produccion = 5f;

    //Costo
    private int nivel = 1;
    private float costo = 115f;

    public GameObject descripcion;
    //public GameObject Boton_normal;
    void Start()
    {
        descripcion.SetActive(false);

    }

    // Update is called once per frame
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
            pizzas_x_seg.AumentarPiz_Seg(produccion);

            produccion += Mathf.Sqrt(produccion);

            amountPizzas.Pizzas -= costo;

            costo = Mathf.Round(260 * Mathf.Pow(1.15f, nivel));

            nivel++;
        }
        else
        {
            Debug.Log("No te alcanza");
        }
    }
}
