using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public GameObject HudPanel;
    public GameObject EndlevelPanel;
    public GameObject ThanksPanel;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            Timer.FreezeTime();
            PlayerScore.CalculateScore();
            EndlevelPanel.GetComponent<EndlevelPanel>().SetupPanel();
            PlayerScore.ResetItems();
            HudPanel.SetActive(false);
            obj.GetComponent<PlayerController>().enabled = false;
            obj.GetComponent<Animator>().SetBool("Is Walking", false);
            Scene current = SceneManager.GetActiveScene();
            string currentLevelName = current.name;
            int index = current.buildIndex;
            if (currentLevelName == "Level 1" )
            {
                PlayerScore.enableSecondLevel = true;
            }
            if (currentLevelName == "Level 2")
            {
                PlayerScore.enableThirdLevel = true;
            }
            if (index < SceneManager.sceneCountInBuildSettings - 1)//Mostra o painel de fim de fase se não for a ultima fase, se for a ultima fase ele mostra o painel de agradecimento por ter jogado.
            {
                EndlevelPanel.SetActive(true);
            }
            else
            {
                ThanksPanel.SetActive(true);
            }
        }
    }
}
