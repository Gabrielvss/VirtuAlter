using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonHUD : MonoBehaviour {

    public Text energies;
    public Text time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (energies != null) //Mantêm atualizado o valor das energias
            energies.text = "Energias: " + PlayerScore.Energies;
        if (time != null) //Mantêm atualizado o valor do tempo.
            time.text = "Tempo: " + Timer.time;
	}
}
