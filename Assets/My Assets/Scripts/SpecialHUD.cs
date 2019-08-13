using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SpecialHUD : MonoBehaviour {

    public GameObject Player;
    public GameObject SpecialItemSpawnerObject;
    public GameObject SpecialEventPanel;
    public GameObject EndLevelPanel;
    public GameObject HUD;
    public GameObject ThanksPanel;

    public Text time;

    public Image LA1;
    public Image LA2;
    public Image LA3;
    public Image LA4;
    public Image LA5;
    public Image RA1;
    public Image RA2;
    public Image RA3;
    public Image RA4;
    public Image RA5;
    //Slides da barra de desequilibrio
    public Slider leftImbalanceBar;
    public Slider rightImbalanceBar;
    //float para guardar o valor do slider.
    public float lBarCurrentValue;
    public float rBarCurrentValue;
    //Velocidade de preenchimento da barra de desequilibrio
    public float fillSpeed = 0.1f;
    public float leveltime;

    static bool CountdownOn = false;
    int p1 = 0;
    int p2 = 0;

	void Start () 
    {
        SpecialEventPanel.SetActive(true);
        StartCoroutine(SpecialEventTextCountdown());

	}
	
	void Update () 
    {
        if (time != null) //Mantêm atualizado o valor do tempo.
            time.text = "Tempo: 00:" + p2 + "" + p1;
        if (CountdownOn)
            Countdown();
        
	}

    public void UpdateSpecialItensHUD(int value)
    {
        switch (value)
        {
            case 5:
                LA1.color = Color.yellow;
                lBarCurrentValue = 20f;
                break;
            case 4:
                LA2.color = Color.yellow;
                lBarCurrentValue = 40f;
                break;
            case 3:
                LA3.color = Color.yellow;
                lBarCurrentValue = 60f;
                break;
            case 2:
                LA4.color = Color.yellow;
                lBarCurrentValue = 80f;
                break;
            case 1:
                LA5.color = Color.yellow;
                lBarCurrentValue = 100f;
                break;
            case 6:
                RA1.color = Color.yellow;
                rBarCurrentValue = 20f;
                break;
            case 7:
                RA2.color = Color.yellow;
                rBarCurrentValue = 40;
                break;
            case 8:
                RA3.color = Color.yellow;
                rBarCurrentValue = 60f;
                break;
            case 9:
                RA4.color = Color.yellow;
                rBarCurrentValue = 80f;
                break;
            case 0:
                RA5.color = Color.yellow;
                rBarCurrentValue = 100f;
                break;
            default:
                break;

        }

    }

    void UpdateBar ()//Função para preencher a barra de forma suave.
    {
        if (lBarCurrentValue > leftImbalanceBar.value)
            leftImbalanceBar.value = leftImbalanceBar.value + (fillSpeed * Time.fixedDeltaTime);
        if (rBarCurrentValue > rightImbalanceBar.value)
            rightImbalanceBar.value = rightImbalanceBar.value + (fillSpeed * Time.fixedDeltaTime);
    }

    void Countdown()
    {
        int remainingItems = SpecialItemSpawnerObject.GetComponent<SpecialItemSpawner>().GetRemaingItems();
        int seconds = Convert.ToInt32(leveltime);
        p1 = seconds - 10 * Convert.ToInt32(seconds / 10);
        p2 = Convert.ToInt32(seconds / 10);
        if (leveltime > 0 && remainingItems > 0)
        {
            leveltime = leveltime - Time.fixedUnscaledDeltaTime;
            if (leveltime < 0)
            {
                leveltime = 0;
            }
        }
        else
        {
            CountdownOn = false;
            EndSpecialLevel();

        }    

    }

    public void EndSpecialLevel()
    {
        SpecialItemSpawnerObject.SetActive(false);
        EndLevelPanel.GetComponent<EndlevelPanel>().SetupSpecialEventPanel(Convert.ToInt32(leveltime));
        HUD.SetActive(false);
        Scene current = SceneManager.GetActiveScene();
        int index = current.buildIndex;
        if (index < SceneManager.sceneCountInBuildSettings - 1)//Mostra o painel de fim de fase se não for a ultima fase, se for a ultima fase ele mostra o painel de agradecimento por ter jogado.
        {
            EndLevelPanel.SetActive(true);
        }
        else
        {
            ThanksPanel.GetComponent<ThanksPanel>().SetupPanel();
            ThanksPanel.SetActive(true);
        }
        Player.GetComponent<PlayerController>().StopPlayer();
    }

    IEnumerator SpecialEventTextCountdown ()
    {
        yield return new WaitForSeconds(5f);
        SpecialEventPanel.SetActive(false);
        SpecialItemSpawnerObject.GetComponent<SpecialItemSpawner>().SpawnNextItem();
        CountdownOn = true;

        yield return 0;
    }
}
