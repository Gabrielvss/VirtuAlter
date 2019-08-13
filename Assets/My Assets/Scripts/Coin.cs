using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Codigo simples para a coleta das energias

public class Coin : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            GetComponent<AudioSource>().Play();
            PlayerScore.AddEnergies();
            Destroy(this.gameObject);
           


        }
        
    

    }
}
