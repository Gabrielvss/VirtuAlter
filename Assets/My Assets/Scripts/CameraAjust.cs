using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ajusta a camera na terceira fase (falta suavização).

public class CameraAjust : MonoBehaviour 
{

    public Transform MainCamera;
    public int mode;
	// Use this for initialization
    void OnTriggerEnter (Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            CameraTransition(MainCamera, mode);
        }
    }

    void CameraTransition (Transform target, int mode)
    {
        switch (mode)
        {
            case 1:
                target.localPosition = new Vector3(0f, 0.82f, -4f);
                target.rotation = Quaternion.Euler( new Vector3(-15f, 0f, 0f));
                break;
            case 2:
                target.localPosition = new Vector3(0f, 2f, -4f);
                target.rotation = Quaternion.Euler( new Vector3(15f, 0f, 0f));
                break;
            default:
                break;
        }

    }


}
