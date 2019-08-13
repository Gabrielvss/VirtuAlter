using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIElements : MonoBehaviour
{
 
    public GameObject mainPanel;
    public GameObject optionsPanel;


    bool isOptionsActive = false;


    void Update()
    {
        if (Input.GetButtonDown("Cancel") && optionsPanel != null)//Ativa/Desativa o menu de opções durante o jogo
            ToggleOptionsPanel(); 
    }

    //HUD Functions
    //A função abaixo atualiza a barra de desequilibrio de acordo com o item especial coletado, como a ordem dos itens especiais na fase
    //estão do menor para o maior valor, é dispensável checar se a barra já está com um valor maior do que o que irá subistitui-lo.
   

    public void ToggleOptionsPanel()//Função para ativar/desativar o  painel de opções
    {
        if (isOptionsActive == false)
        {
            optionsPanel.SetActive(true);
            isOptionsActive = true;
        }
        else
        {
            optionsPanel.SetActive(false);
            isOptionsActive = false;
        }
    }

    public void QuitGame()//Função para sair do jogo (não irá funcionar se o jogo for rodado dentro do unity)
    {
        Application.Quit();
    }

    public void Restart()//Reinicia a fase
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGame()//Carrega a primeira cena.
    {
        SceneManager.LoadScene(1);
    }
        
}
  
