using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyConverterTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        string str = Input.inputString;
        int num = 0;
        try
        {
        num = Convert.ToInt16(str);

        Debug.Log("Converteu Krai");
        }
        catch (FormatException)
        {
            Debug.Log("nao é possivel converter");
        }

        Debug.Log(str + " " + num );
		
	}
}
