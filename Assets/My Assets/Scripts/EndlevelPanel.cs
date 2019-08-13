using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Script para coletar todos as informações que o Painel de fim de fase precisa.

public class EndlevelPanel : MonoBehaviour {


    public Image[] sItem = new Image[10];

    public Text time;
    public Text energies;
    public Text score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))//Muda de fase quando uma das teclas for pressionada.
        {
            Scene current = SceneManager.GetActiveScene();
            int index = current.buildIndex + 1;
            SceneManager.LoadScene(index);
        }
	}

    public void SetupPanel ()//Coloca todas as informações no painel.
    {
        time.text = "  Tempo: "+ Timer.time;
        energies.text = "  Energias: " + PlayerScore.Energies + "/20";
        score.text = "  Pontuação: " + PlayerScore.Score;

    }

    public void SetupSpecialEventPanel(int remainingSec)
    {
        PlayerScore.CalculateScore();
        time.text = "Tempo Restante: " + remainingSec + " Segundos";
        score.text = " Pontuação: " + PlayerScore.Score;
        for (int i = 0; i < 10; i++)
        {
            if (PlayerScore.GetSpecialItems(i))
            {
                sItem[i].color = Color.yellow;
            }
        }
    }

}
