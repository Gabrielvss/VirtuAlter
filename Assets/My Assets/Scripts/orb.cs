using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject,1);
            PlayerScore.AddEnergies();

        }



    }
}
