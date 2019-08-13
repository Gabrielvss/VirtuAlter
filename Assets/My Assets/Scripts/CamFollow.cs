using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public GameObject player;
    Vector3 newPosition;
    public float height = 1.2f;
    public float distance = 1.8f;

    //Simple camera follow script

    void FixedUpdate ()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
            newPosition = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z - distance);
            transform.position = newPosition;
        }
    }
}
