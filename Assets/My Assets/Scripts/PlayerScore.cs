using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script gerencia todos os pontos e itens que o jogador pode coletar

public static class PlayerScore
{

    private static int energies = 0;
    private static int score = 0;
    /*Variaveis do tipo Bool pra cada item especial.
    Sendo a seguinte organização das variaveis com relação ao hud:

    lA5 lA4 lA3 lA2 lA1 rA1 rA2 rA3 rA4 rA5*/

    private static bool lA1 = false;
    private static bool lA2 = false;
    private static bool lA3 = false;
    private static bool lA4 = false;
    private static bool lA5 = false;
    private static bool rA1 = false;
    private static bool rA2 = false;
    private static bool rA3 = false;
    private static bool rA4 = false;
    private static bool rA5 = false;

   public static bool enableSecondLevel = false;
   public static bool enableThirdLevel = false;

    public static int Energies
    {
        get { return energies; }
    }

    public static int Score
    {
        get { return score; }
    }

    public static void AddEnergies()
    {
        energies++;
    }

    public static void CalculateScore()//Calcula a quantidade de pontos que o jogador terá (usado no final de cada fase)
    {
        score = score + energies * 10;
        if (lA1)
            score = score + 10;
        if (lA2)
            score = score + 20;
        if (lA3)
            score = score + 30;
        if (lA4)
            score = score + 40;
        if (lA5)
            score = score + 50;
        if (rA1)
            score = score + 10;
        if (rA2)
            score = score + 20;
        if (rA3)
            score = score + 30;
        if (rA4)
            score = score + 40;
        if (rA5)
            score = score + 50;
    }

    public static bool GetSpecialItems(int value) //retorna se um determinado item foi coletado.
    {
        switch (value)
        {
            case 5:
                return lA1;

            case 4:
                return lA2;

            case 3:
                return lA3;

            case 2:
                return lA4;

            case 1:
                return lA5;

            case 6:
                return rA1;

            case 7:
                return rA2;

            case 8:
                return rA3;

            case 9:
                return rA4;
               
            case 0:
                return rA5;

            default:
                return false;
               
        }
    }
    public static void SpecialItensGathering(int value) //Muda o estado da variavel para true se o item for coletado.
    {
        switch (value)
        {
            case 5:
                lA1 = true;
                break;
            case 4:
                lA2 = true;
                break;
            case 3:
                lA3 = true;
                break;
            case 2:
                lA4 = true;
                break;
            case 1:
                lA5 = true;
                break;
            case 6:
                rA1 = true;
                break;
            case 7:
                rA2 = true;
                break;
            case 8:
                rA3 = true;
                break;
            case 9:
                rA4 = true;
                break;
            case 0:
                rA5 = true;
                break;
            default:
                break;

        }
    }
    public static void ResetItems ()
    {

        energies = 0;

        lA1 = false;
        lA2 = false;
        lA3 = false;
        lA4 = false;
        lA5 = false;
        rA1 = false;
        rA2 = false;
        rA3 = false;
        rA4 = false;
        rA5 = false;
    }
}
