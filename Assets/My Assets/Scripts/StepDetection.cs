using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDetection : MonoBehaviour
{
    //Objetos na cena para detectar o chão, o step e se existe uma queda na frente (respectivamente).
    public GameObject floorDetect;
    public GameObject stepDetect;
    public GameObject fallDetect;

    int layerMask = 1 << 8;//A layer que será checada.

    void Start()
    {
        
    }

    void Update()
    {
        //Atribui a posição do centro de detecção e dos pés, que é de onde sairá o raycast.
        Vector3 centerposition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Vector3 feetposition = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);

        FloorDetection(centerposition);
        FallDetection(centerposition);
        StepDetect(feetposition);
    }

    IEnumerator ObjectCoolDown(GameObject obj)//Gerencia o cooldown dos detectores, a fim de evitar multiplas detecções.
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(5f);
        obj.SetActive(true);
    }

    void FallDetection(Vector3 position)//Função para checar se existe uma queda.
    {
        /* Manda uma linha da posição do centro do personagem até o objeto falldetect, para verificar se existe um objeto entre eles.*/
        if (!Physics.Linecast(position, fallDetect.transform.position, layerMask))
        {
            Debug.DrawLine(position, fallDetect.transform.position);//Desenha a linha no unity.
            GetComponent<Animator>().SetBool("HasFall", true);
            if (fallDetect.activeSelf)
            {
                
                StartCoroutine(ObjectCoolDown(fallDetect));
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("HasFall", false);
        }
    }

    void FloorDetection(Vector3 position)//Função para verificar se o personagem está no chão.
    {
        /* Manda uma linha da posição do centro do personagem até o objeto floordetect, para verificar se existe um objeto entre eles.*/
        if (Physics.Linecast(position, floorDetect.transform.position, layerMask))
        {
            GetComponent<Animator>().SetBool("HasFloor", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("HasFloor", false);
        }
    }

    void StepDetect(Vector3 position)//Função para verificar se existe um step na frente.
    {
        RaycastHit obj;
        /* Manda uma linha da posição dos pés do personagem até o objeto stepdetect, para verificar se existe um step proximo.*/
        if (Physics.Linecast(position, stepDetect.transform.position, out obj, layerMask))
        {
            if (obj.transform.CompareTag("Step"))
            {
                GetComponent<Animator>().SetBool("HasStep", true);
                if (stepDetect.activeSelf)
                {
               
                    StartCoroutine(ObjectCoolDown(stepDetect));
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("HasStep", false);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("HasStep", false);
        }

    }


}

