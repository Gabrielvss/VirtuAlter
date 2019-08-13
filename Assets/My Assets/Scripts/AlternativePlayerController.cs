using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Obsoleto.

public class AlternativePlayerController : MonoBehaviour
{
    public float forwardForce = 1;
    public float jumpforce = 1;
    public GameObject RightHand;
    public GameObject LeftHand;
    public bool hasFloor;
    public bool hasFall;

    bool isGetDownOnCooldown = false;

    void FixedUpdate()
    {
        Step();
        GetDown();
        RightHandLow();
        LeftHandLow();
        RightHandHigh();
        LeftHandHigh();
        DeactivateHands();
    }
    // Dois IEnumerators para gerenciar o delay do inicio do movimento de subir e descer o degrau para sincronizar com as animações.
    // Um IEnumerator para gerenciar o cooldown do movimento de descer o degrau, para evitar que seja ativado multiplas vezes.

    IEnumerator GetDownCooldown()
    {
        isGetDownOnCooldown = true;
        yield return new WaitForSeconds(1f);
        isGetDownOnCooldown = false;
    }

    IEnumerator StepDelay()
    {
        yield return new WaitForSeconds(0.6f);
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpforce);//Faz o personagem subir.
       
    }

    IEnumerator GetDownDelay()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector3.forward * 0.25f);
        yield return new WaitForSeconds(0.5f);

    }

    void Step()
    {
        //Se o personagem não estiver no ar, ele poderá fazer o movimento de step
        StartCoroutine(StepDelay());//Atrasa o movimento de subir o degrau para sincronizar com a animação.
        GetComponent<Animator>().SetTrigger("Step");
        GetComponent<Animator>().SetBool("Idle", false);
    }

    void GetDown()
    {
        if (Input.GetButton("GetDown") && GetComponent<Animator>().GetBool("Idle") && GetComponent<Animator>().GetBool("HasFloor") && GetComponent<Animator>().GetBool("HasFall") && !isGetDownOnCooldown)
        {
            StartCoroutine(GetDownDelay());//Atrasa o movimento de descer o degrau para sincronizar com a animação.
            StartCoroutine(GetDownCooldown());//Evita que esta função seja ativada multiplas vezes.
            GetComponent<Animator>().SetTrigger("GetDown");
            GetComponent<Animator>().SetBool("Idle", false);
        }
			
    }

    void RightHandLow()//Gerencia o estado da mão direita estar baixa.
    {
        if (Input.GetButton("RightHandLow") && !Input.GetButton("LeftHandLow") && !Input.GetButton("LeftHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkRightHandLow");
            RightHand.SetActive(true);
            RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, 0.8f, RightHand.transform.localPosition.z);
        }
        else
        {
            if (!Input.GetButton("RightHandHigh"))
            {
                GetComponent<Animator>().SetBool("RightHandLow", false);

            }
        }
    }

    void LeftHandLow() //Gerencia o estado de a mão esquerda estar baixa.
    {
        if (Input.GetButton("LeftHandLow") && !Input.GetButton("RightHandHigh") && !Input.GetButton("RightHandLow") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkLeftHandLow");
            LeftHand.SetActive(true);
            LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, 0.8f, LeftHand.transform.localPosition.z);
        }
    }

    void RightHandHigh() // Gerencia o estado de a mão direita estar alta
    {
        if (Input.GetButton("RightHandHigh") && !Input.GetButton("LeftHandLow") && !Input.GetButton("LeftHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkRightHandHigh");	
            RightHand.SetActive(true);
            RightHand.transform.localPosition = new Vector3(RightHand.transform.localPosition.x, 1.35f, RightHand.transform.localPosition.z);
        }

    }

    void LeftHandHigh() //Gerencia o estado de a mão esquerda estar alta.
    {
        if (Input.GetButton("LeftHandHigh") && !Input.GetButton("RightHandLow") && !Input.GetButton("RightHandHigh") && !GetComponent<Animator>().GetBool("Idle"))
        {
            GetComponent<Animator>().Play("WalkLeftHandHigh");	
            LeftHand.SetActive(true);
            LeftHand.transform.localPosition = new Vector3(LeftHand.transform.localPosition.x, 1.35f, LeftHand.transform.localPosition.z);
        }
    }

    void DeactivateHands() //Desativa os colisores das mãos caso nenhum dos comandos esteja ativo.
    {
        if (!Input.GetButton("RightHandHigh") && !Input.GetButton("RightHandLow") && !Input.GetButton("RightHighAndLeftLow") && !Input.GetButton("RightLowAndLeftHigh"))
            RightHand.SetActive(false);
		
        if (!Input.GetButton("LeftHandHigh") && !Input.GetButton("LeftHandLow") && !Input.GetButton("RightHighAndLeftLow") && !Input.GetButton("RightLowAndLeftHigh"))
            LeftHand.SetActive(false);
    }
}

