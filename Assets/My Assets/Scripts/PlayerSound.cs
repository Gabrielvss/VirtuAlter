using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Começo de um scrpit para gerenciar os sons do jogo.

public class PlayerSound : MonoBehaviour {

    AudioSource WalkSand;
    AudioSource WalkWood;
    AudioSource Step1;
    AudioSource Step2;
    AudioSource toPlay;
    AudioSource previousAudio;
    int terrainType = 0;


    /* Types of Terrain

    0 - Sand;
    1 - Wood:

    */

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    /*void WalkSound ()
    {
        previousAudio = toPlay;
        if (GetComponent<Animator>().GetBool("iS Walking"))
        {
            
            switch (terrainType)
            {
                case 0:
                    toPlay = WalkSand;
                    break;
                case 1:
                    toPlay = WalkSand;
                    break;
                default:
                    toPlay = WalkSand;
                    break;
            }
        }

        else
        {
            previousAudio.Stop;
        }
    }*/
}
