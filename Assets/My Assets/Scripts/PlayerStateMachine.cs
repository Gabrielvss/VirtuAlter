using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    State state;

    bool hasStep = false;

    enum State
    {
        Idle,
        Walk,
        StepUp,
        StepDown,
        IRightHigh,
        IRightLow,
        ILeftLow,
        ILeftHigh,
        IRightHighLeftHigh,
        IRightHighLeftLow,
        IRightLowLeftHigh,
        IRightLowLeftLow,
    };

    void Start()
    {
        state = State.Idle;
    }
	
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (State.Idle):
                IdleState();
                break;
            case (State.Walk):
                WalkState();
                break;
            case (State.StepUp):
                StepUpState();
                break;
            case (State.StepDown):
                StepDownState();
                break;
            case (State.IRightHigh):
                IRightHighState();
                break;
            case (State.IRightLow):
                IRightLowState();
                break;
                
        }
    }

    void IdleState()
    {
        if (Input.GetButton("StepUp") && hasStep)
        {
            state = State.StepUp;
        }
        else
        {
            if (Input.GetButton("Walk"))
            {

            }
            else
            {
                if (Input.GetButton("RightHigh"))
                {

                }
                else
                {
                    if (Input.GetButton("RightLow"))
                    {

                    }
                    else
                    {
                        if (Input.GetButton("LeftHigh"))
                        {

                        }
                        else
                        {
                            if (Input.GetButton("LeftLow"))
                            {

                            }
                        }
                    }
                }
            }
        }
    }

    void WalkState()
    {
        if (!Input.GetButton("Walk"))
        {

        }
    }

    void StepUpState()
    {
        
    }

    void StepDownState()
    {
        
    }

    void IRightHighState()
    {
        
    }

    void IRightLowState()
    {
        
    }

    void ILeftHighState()
    {
        
    }

    void ILeftLowState()
    {
        
    }

    void IRightHighLeftHighState()
    {
        
    }

    void IRightHighLeftLowState()
    {
        
    }

    void IRightLowLeftHithState()
    {
        
    }

    void IRightLowLeftLowState()
    {
        
    }
}

   
