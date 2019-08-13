using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanksPanel : MonoBehaviour {

    public Text score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.E))
            Application.Quit();
	}

    public void SetupPanel ()//Coloca todas as informações no painel.
    {
        
        score.text = "  Pontuação: " + PlayerScore.Score;

    }
}
