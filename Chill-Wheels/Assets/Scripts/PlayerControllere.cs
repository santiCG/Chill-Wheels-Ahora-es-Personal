using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AmountPizzas PuntajePizzas;

    Animator animator;

    public float speed = 100f;
    public float JumpHeight;
    public bool InAir = false;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        InAir = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        InAir = true;
    }

    void Update()
    {
        animator.SetFloat("y", transform.position.y);

        animator.SetTrigger("Jump");

        Vector2 NoMovement = new Vector2(0f, 0f);

        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (InAir == false)
            {
                rb2d.AddForce(new Vector2(0, JumpHeight * 1.5f), ForceMode2D.Impulse);

                //StartCoroutine(EsperarUnSegundo());
            }
        }
    }

    private IEnumerator EsperarUnSegundo()
    {
        yield return new WaitForSeconds(0.2f);

    }

    public void ContadorPizzas(float amount)
    {
        PuntajePizzas.SumarPizzas(amount);
    }
}