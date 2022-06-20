using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoNegro : MonoBehaviour
{
    public Puntaje puntaje;
    public static bool golazo { get; private set; }
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        golazo = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!golazo)
        {
            if(collision.tag == "ScoreRojo")
            {
                golazo = true;
                puntaje.Goal(Puntaje.Score.PlayerBlue);
                StartCoroutine(ReiniciarDiscoNegro());
            }else if(collision.tag == "ScoreAzul")
            {
                golazo = true;
                puntaje.Goal(Puntaje.Score.PlayerRed);
                StartCoroutine(ReiniciarDiscoNegro());
            }
        }
    }

    public void Centro()
    {
        rb.position = new Vector2(0, 0);
    }

    private IEnumerator ReiniciarDiscoNegro()
    {
        yield return new WaitForSecondsRealtime(1);
        golazo = false;
        rb.position = rb.velocity = new Vector2(0, 0);
    }

}
