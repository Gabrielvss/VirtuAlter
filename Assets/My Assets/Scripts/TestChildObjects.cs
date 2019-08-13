using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChildObjects : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Transform T = transform.GetChild(9);
        Debug.Log(T.name);
        T = transform.GetChild(11);
        Debug.Log(T.name);


    }
	
    // Update is called once per frame
    void Update()
    {
		
    }
}
