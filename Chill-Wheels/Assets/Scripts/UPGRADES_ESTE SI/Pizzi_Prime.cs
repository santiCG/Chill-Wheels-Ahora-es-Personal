using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Pizzi_Prime : MonoBehaviour
{
    
    public GameObject descripcion;
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
        Debug.Log("aqui va la accion de click"); 

       
    }
}
