using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Piz_x_seg : MonoBehaviour
{
    [SerializeField] private AmountPizzas PuntajePizzas;

    public float pizzas_seg;

    private TextMeshProUGUI _textMeshPro;

    private float tiempoPasado = 0f;
    private float tiempoEsperado = 1f;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textMeshPro.text = pizzas_seg.ToString("0") + " P/S";

        tiempoPasado += Time.deltaTime;
        if (tiempoPasado >= tiempoEsperado)
        {
            PuntajePizzas.SumarPizzas(pizzas_seg);

            tiempoPasado = 0f; // Reinicia el contador.
        }
    }

    public void AumentarPiz_Seg(float value)
    {
        pizzas_seg += value;
    }
}
