using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{

    public GameObject Trajectory;
    Transform CurrentDestination;
    Transform[] Points = new Transform[9];
    int i = 2;

    // Use this for initialization
    void Start()
    {
        ConfigureTrajectory();
        GetComponent<NavMeshAgent>().SetDestination(CurrentDestination.position);
    }
	
    // Update is called once per frame
    void Update()
    {
        ChangeDestination();
    }

    void ConfigureTrajectory ()
    {
        Points = Trajectory.GetComponentsInChildren<Transform>();
        CurrentDestination = Points[1];
    }

    void ChangeDestination ()
    {
        if (Vector3.Distance(transform.position, CurrentDestination.position) < 0.5f)
        {
            CurrentDestination = Points[i];
            GetComponent<NavMeshAgent>().SetDestination(CurrentDestination.position);
            if (i < Points.Length-1)
            {
                i++;
            }
        }
    }
}
