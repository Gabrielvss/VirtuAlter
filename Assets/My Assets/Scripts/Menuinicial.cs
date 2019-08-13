using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{

    public Button level2;
    public Button level3;
    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menuinicial")
        {
            if (!PlayerScore.enableSecondLevel)

            {
                level2.interactable = false;
            }
            else
            {
                level2.interactable = true;
            }
            if (!PlayerScore.enableThirdLevel)
            {
                level3.interactable = false;
            }
            else
            {
                level3.interactable = true;
            }
        }
    }

    

    public void chamalevel1(){
    
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");

}

    public void chamalevel2(){

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 2");

    }

    public void chamalevel3(){

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 3");

    }

    public void chamamenu()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Menuinicial");

    }

    public void SairDoJogo()
    {

        Application.Quit();

    }

}
