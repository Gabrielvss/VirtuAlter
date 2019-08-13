using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerController : MonoBehaviour
{
    //Dois colisores que estão presentes na cena, cada um é designado para uma mão e serão ativados, desativados ou movidos de acordo com
    //os inputs do jogador
    public GameObject RightHand;
    public GameObject LeftHand;
    //Estas são as coordenadas (no plano x,y) das energias purpura, as mãos serão mandadas para estas coordenadas quando o comando for
    // dado pelo input.
    public float lowWidth = 0.45f;
    public float highWidth = 0.5f;
    public float lowHeight = 9f;
    public float highHeight = 1.5f;
    //Essas são as velocidade e a força que o personagem sobe no degrau.
    public float speed = 1;
    public float stepForce = 1f;

    //Coordenadas dos itens especiais (amarelos). 

    public static ICoordinates I1 = new ICoordinates(0.7f,1.75f);
    public static ICoordinates I2 = new ICoordinates(0.75f,1.6f);
    public static ICoordinates I3 = new ICoordinates(0.8f,1.475f);
    public static ICoordinates I4 = new ICoordinates(0.85f,1.32f);
    public static ICoordinates I5 = new ICoordinates(0.8f,1.15f);

    public bool IsMovementActive = true;
    public bool IsInclinationActive = false;
    public bool IsHandActive = true;

    public struct ICoordinates //Estrutura de coordenadas.
    {
        public float x;
        public float y;

        public ICoordinates (float i, float j)
        {
            x = i;
            y = j;
        }
    }

    void Start()
    {

    }



    void FixedUpdate()
    {   
        if (IsInclinationActive)
            Inclination();//Gerencia a inclinação do personagem.
        if (IsMovementActive)
            PlayerMovement();//Gerencia o movimento do personagem, incluindo o movimento das mãos sem inclinação do corpo.
        if(IsHandActive)
            PlayerHands();

    }

    IEnumerator DelayStepDown()//Atrasa o movimento de descer o step para sincronizar com a animação.
    {
        
        yield return new WaitForSeconds(0.6f);
        yield return new WaitForSeconds(0.025f);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 4f, ForceMode.Impulse);

    }
 
    IEnumerator DelayStep()//Atrasa o movimento de subir do step para sincronizar com a animação.
    {
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.Translate(Vector3.up * stepForce);
        yield return new WaitForSeconds(0.025f);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 3f, ForceMode.Impulse);

    }

    public void StopPlayer()
    {
        IsMovementActive = false;
        IsHandActive = false;
        IsInclinationActive = false;
    }

    public void ForceIdle()
    {
        GetComponent<Animator>().SetBool("Idle", true);
        GetComponent<Animator>().Play("Idle");
    }

    public void StepDown()
    {
        StartCoroutine(DelayStepDown());
    }

    public void Step()
    {
        StartCoroutine(DelayStep());
    }

    public void DeactivateHands(string layerName)//Função para desativar os colisores das mãos quando não estiverem sendo usados.
    {
        if (layerName == "Right Hand" || layerName == "Right Inclination")
        {
            RightHand.SetActive(false);
        }
        else
        {
            LeftHand.SetActive(false);
        }
    }

    public void HandBehaviour(string layerName, AnimatorStateInfo state)//Função para colocar o colisor da mão no local onde ela estiver.
    {
        if (layerName == "Right Hand")
        {
            if (state.IsName("Hand High"))
            {
                RightHand.SetActive(true);
                RightHand.transform.localPosition = new Vector3(highWidth, highHeight, 0.2f);
                RightHand.transform.localRotation = Quaternion.identity;
            }
            else
            {
                RightHand.SetActive(true);
                RightHand.transform.localPosition = new Vector3(lowWidth, lowHeight, 0.25f);
                RightHand.transform.localRotation = Quaternion.identity;
            }
        }
        else
        {
            if (state.IsName("Hand High"))
            {
                LeftHand.SetActive(true);
                LeftHand.transform.localPosition = new Vector3(-highWidth, highHeight, 0.2f);
                RightHand.transform.localRotation = Quaternion.identity;
            }
            else
            {
                LeftHand.SetActive(true);
                LeftHand.transform.localPosition = new Vector3(-lowWidth, lowHeight, 0.25f);
                RightHand.transform.localRotation = Quaternion.identity;
            }
        }

    }
    //Gerencia a posição do colisor das mãos do personagens de acordo com a posição das mãos na animação de inclinação.
    public void InclinationBehaviour(string layerName, AnimatorStateInfo state)
    {
        if (layerName == "Right Inclination")
        {
            
            if (state.IsName("One"))
            {
                RightHand.SetActive(true);
                RightHand.transform.localPosition = new Vector3(I1.x, I1.y, 0);
                RightHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
            }
            else
            {
                if (state.IsName("Two"))
                {
                    RightHand.SetActive(true);
                    RightHand.transform.localPosition = new Vector3(I2.x, I2.y, 0);
                    RightHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else
                {
                    if (state.IsName("Three"))
                    {
                        RightHand.SetActive(true);
                        RightHand.transform.localPosition = new Vector3(I3.x, I3.y, 0);
                        RightHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                    }
                    else
                    {
                        if (state.IsName("Four"))
                        {
                            RightHand.SetActive(true);
                            RightHand.transform.localPosition = new Vector3(I4.x, I4.y, 0);
                            RightHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                        }
                        else
                        {
                            RightHand.SetActive(true);
                            RightHand.transform.localPosition = new Vector3(I5.x, I5.y, 0);
                            RightHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                        }
                    }
                }
            }
        }
        else
        {
            if (state.IsName("One"))
            {
                LeftHand.SetActive(true);
                LeftHand.transform.localPosition = new Vector3(-I1.x, I1.y, 0);
                LeftHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
            }
            else
            {
                if (state.IsName("Two"))
                {
                    LeftHand.SetActive(true);
                    LeftHand.transform.localPosition = new Vector3(-I2.x, I2.y, 0);
                    LeftHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                }
                else
                {
                    if (state.IsName("Three"))
                    {
                        LeftHand.SetActive(true);
                        LeftHand.transform.localPosition = new Vector3(-I3.x, I3.y, 0);
                        LeftHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                    }
                    else
                    {
                        if (state.IsName("Four"))
                        {
                            LeftHand.SetActive(true);
                            LeftHand.transform.localPosition = new Vector3(-I4.x, I4.y, 0);
                                LeftHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                        }
                        else
                        {
                            LeftHand.SetActive(true);
                            LeftHand.transform.localPosition = new Vector3(-I5.x, I5.y, 0);
                                LeftHand.transform.localRotation = Quaternion.AngleAxis(90, Vector3.up);
                        }
                    }
                }
            }
        }
    }

    void Inclination()//Gerencia as variaveis de para a inclinação no animator.
    {
        if (Input.GetButton("Right One"))
            GetComponent<Animator>().SetBool("Right One", true);
        else
            GetComponent<Animator>().SetBool("Right One", false);
        
        if (Input.GetButton("Right Two"))
            GetComponent<Animator>().SetBool("Right Two", true);
        else
            GetComponent<Animator>().SetBool("Right Two", false);

        if (Input.GetButton("Right Three"))
            GetComponent<Animator>().SetBool("Right Three", true);
        else
            GetComponent<Animator>().SetBool("Right Three", false);

        if (Input.GetButton("Right Four"))
            GetComponent<Animator>().SetBool("Right Four", true);
        else
            GetComponent<Animator>().SetBool("Right Four", false);

        if (Input.GetButton("Right Five"))
            GetComponent<Animator>().SetBool("Right Five", true);
        else
            GetComponent<Animator>().SetBool("Right Five", false);
        
        if (Input.GetButton("Left One"))
            GetComponent<Animator>().SetBool("Left One", true);
        else
            GetComponent<Animator>().SetBool("Left One", false);

        if (Input.GetButton("Left Two"))
            GetComponent<Animator>().SetBool("Left Two", true);
        else
            GetComponent<Animator>().SetBool("Left Two", false);

        if (Input.GetButton("Left Three"))
            GetComponent<Animator>().SetBool("Left Three", true);
        else
            GetComponent<Animator>().SetBool("Left Three", false);

        if (Input.GetButton("Left Four"))
            GetComponent<Animator>().SetBool("Left Four", true);
        else
            GetComponent<Animator>().SetBool("Left Four", false);
           
        if (Input.GetButton("Left Five"))
            GetComponent<Animator>().SetBool("Left Five", true);
        else
            GetComponent<Animator>().SetBool("Left Five", false);
    }

    void PlayerMovement()//Gerencia as variaveis de movimento, e levantar ou abaixar as mãos no animator.
    {
        if (Input.GetButton("Walk"))
            GetComponent<Animator>().SetBool("Is Walking", true);
        else
            GetComponent<Animator>().SetBool("Is Walking", false);
        
        if (Input.GetButton("StepUp"))
            GetComponent<Animator>().SetBool("StepUp", true);
        else
            GetComponent<Animator>().SetBool("StepUp", false);
        

        if (Input.GetButtonUp("StepUp"))
            GetComponent<Animator>().SetBool("StepDown", true);
        else
            GetComponent<Animator>().SetBool("StepDown", false);
        
    }
    void PlayerHands ()
    {
        if (Input.GetButton("LeftLow"))
            GetComponent<Animator>().SetBool("Left Low", true);
        else
            GetComponent<Animator>().SetBool("Left Low", false);


        if (Input.GetButton("LeftHigh"))
            GetComponent<Animator>().SetBool("Left High", true);
        else
            GetComponent<Animator>().SetBool("Left High", false);


        if (Input.GetButton("RightLow"))
            GetComponent<Animator>().SetBool("Right Low", true);
        else
            GetComponent<Animator>().SetBool("Right Low", false);


        if (Input.GetButton("RightHigh"))
            GetComponent<Animator>().SetBool("Right High", true);
        else
            GetComponent<Animator>().SetBool("Right High", false);
    }

    public static ICoordinates GetItemCoordinates (int index)
    {
        switch (index)
        {
            case 1:
                return I1;
            
            case 2:
                return I2;

            case 3:
                return I3;

            case 4:
                return I4;

            case 5:
                return I5;

            default:
                return new ICoordinates(0f,0f);

        }
    }
}
