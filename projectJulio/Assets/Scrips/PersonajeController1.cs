using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    public float velMovement = 5f; // Velocidad de movimiento del personaje
    public float fuerzaJump = 7f; //Fuerza dle salto dle personaje 
    private bool enElsuelo = false; //Indicador si el personaje est en el suelo
    private bool mirandoDerecha = true;//Indica el sentido donde mira el personaje
   

    private Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    void Update()
    {

        //movimiento horizonal
        float movimientoH = Input.GetAxis("Horizontal");

        //sentido personaje
        if(movimientoH > 0 && !mirandoDerecha){
            Girar();
        }

        else if(movimientoH < 0 && mirandoDerecha){
            Girar();
        }

        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));
        animator.SetBool("enSuelo",enElsuelo);
        animator.SetFloat("VelocidadY", rb.velocity.y);

        //Salto
        if (Input.GetKey(KeyCode.UpArrow) && enElsuelo)
        {
            Debug.Log("Salto");
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);
            enElsuelo = false;
        }

    }

        void OnCollisionEnter2D (Collision2D collision)
        {
            //Verificar si el personaje est� en el suelo
            if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("PlataformaC") || collision.gameObject.CompareTag("PlataformaM"))
            {
                enElsuelo = true;
                Debug.Log("Si toco el suelo");
            }

            if (collision.gameObject.CompareTag("PlataformaM"))
            {
                transform.parent = collision.transform;
            }
        }

        private void OnCollisionExit2D (Collision2D collision)
        {
            if(collision.gameObject.CompareTag("PlataformaM"))
            {
                transform.parent = null;
            }
        }

        private void Girar()
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }

    }

