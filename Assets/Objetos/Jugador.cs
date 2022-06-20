using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    bool click = true;
    bool mover;
    Vector2 tama�oJugador;
    Rigidbody2D rb;
    public Transform Limites;
    Limits jugadorTrans;

    struct Limits
    {
        public float Arriba, Abajo, Izquierda, Derecha;

        public Limits(float arriba, float abajo, float izquierda, float derecha)
        {
            Arriba = arriba;
            Abajo = abajo;
            Derecha = derecha;
            Izquierda = izquierda;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        tama�oJugador = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        rb = gameObject.GetComponent<Rigidbody2D>();

        jugadorTrans = new Limits(Limites.GetChild(0).position.y,
                                  Limites.GetChild(1).position.y,
                                  Limites.GetChild(2).position.x,
                                  Limites.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()
    {
        //Si hizo click 
        // 0 hace referencia al click izquierdo.
        if (Input.GetMouseButton(0) == true)
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print(mousePos);
            //print(tama�oJugador);
            if(click == true)
            {
                click = false;

                if((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + tama�oJugador.x ||
                    mousePos.x <= transform.position.x && mousePos.x > transform.position.x - tama�oJugador.x)
                    && (mousePos.y >= transform.position.x && mousePos.y < transform.position.y + tama�oJugador.y ||
                    mousePos.y <= transform.position.y && mousePos.y > transform.position.y - tama�oJugador.y))
                {
                    mover = true;
                }else
                {
                    mover = false;
                }
            }
            if (mover == true)
            {
                Vector2 anclarPosM = new Vector2(Mathf.Clamp(mousePos.x, jugadorTrans.Izquierda,
                                                                         jugadorTrans.Derecha),
                                                Mathf.Clamp(mousePos.y, jugadorTrans.Abajo,
                                                                        jugadorTrans.Arriba));
                rb.MovePosition(anclarPosM);
            }
        }
        else
        {
            click = true;
        }
    }

    public void StartPosition(bool Azul)
    {
        if (Azul== true)
        {
            rb.position = new Vector2(7,0);
        }else
        {
            rb.position = new Vector2(-7,0);
        }
    }
}
