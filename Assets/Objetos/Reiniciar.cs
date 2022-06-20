using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reiniciar : MonoBehaviour
{

    public GameObject CanvasScores;
    public GameObject CanvasReiniciar;

    public GameObject GanadorTxt;
    public Text Ganador;

    public Puntaje puntaje;

    public DiscoNegro discoNegro;
    public Jugador jugadorRojo;
    public Jugador jugadorAzul;


    public void MenuReiniciar(bool ganadorAzul)
    {
        CanvasScores.SetActive(false);
        CanvasReiniciar.SetActive(true);
        if (ganadorAzul)
        {
            GanadorTxt.SetActive(true);
            Ganador.text = ("Ganó Azul").ToString();
        }
        else
        {
            GanadorTxt.SetActive(true);
            Ganador.text = ("Ganó Rojo").ToString();
        }
    }

    public void ReinicarJuego()
    {
        CanvasReiniciar.SetActive(false);
        CanvasScores.SetActive(true);

        puntaje.Reiniciar();
        discoNegro.Centro();
        jugadorAzul.StartPosition(true);
        jugadorRojo.StartPosition(false);
    }
}
