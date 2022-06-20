using UnityEngine.UI;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public enum Score
    {
        PlayerRed, PlayerBlue
    }
    public Text ScoreRojo, ScoreAzul;
    private int playerScoreRojo, playerScoreAzul;
    public Reiniciar re;

    public int MaxScore;

    private int scoreRojo, scoreAzul;
    private int PlayerRed
    {
        get { return scoreRojo; }
        set
        {
            scoreRojo = value;
            if(value == MaxScore)
            {
                re.MenuReiniciar(false);
            }
        }
    }
    private int PlayerBlue
    {
        get { return scoreAzul; }
        set
        {
            scoreAzul = value;
            if (value == MaxScore)
            {
                re.MenuReiniciar(true);
            }
        }
    }


    public void Goal(Score jugador)
    {
        if (jugador == Score.PlayerRed)
            ScoreRojo.text = (++PlayerRed).ToString();
        else
            ScoreAzul.text = (++PlayerBlue).ToString();

    }

    public void Reiniciar()
    {
        PlayerBlue = PlayerRed = 0;
        ScoreRojo.text =  ScoreAzul.text = "0";
    }
}
