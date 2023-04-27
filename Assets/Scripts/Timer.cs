using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int minutes;

    [SerializeField]
    private int seconds;

    private int m, s;

    [SerializeField]
    private Text timerText;

    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController= gameObject.GetComponent<GameController>();  
    }

    public void startTimer()
    {
        m = minutes;
        s = seconds;
        writerTimer(m, s);
        Invoke("updateTimer", 1f);//El metodo se invoque así mismo en intervalos de 1 segundo
    }

    public void stopTimer()
    {
        CancelInvoke();

    }

    private void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                //endgame
                gameController.endGame();
                return;
            }
            else
            {
                m--;
                s = 59;
            }
        }
        writerTimer(m, s);
        Invoke("updateTimer", 1f);
    }
    private void writerTimer(int m, int s)
    {
        if (s < 10)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }

    }
}
