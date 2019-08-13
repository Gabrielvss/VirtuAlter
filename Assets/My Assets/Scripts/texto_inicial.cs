using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class texto_inicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))//Muda de fase quando uma das teclas for pressionada.
        {
            Scene current = SceneManager.GetActiveScene();
            int index = current.buildIndex + 1;
            SceneManager.LoadScene(index);
        }

    }
}
