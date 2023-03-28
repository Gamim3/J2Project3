using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;

public class CharUX : MonoBehaviour
{
    [SerializeField] private ContinuousMoveProviderBase movement;
    [SerializeField] private TeleportationProvider teleport;
    [SerializeField] private ContinuousTurnProviderBase smoothTurn;
    [SerializeField] private SnapTurnProviderBase snapTurn;
    private int index;

    private bool movementType;
    private bool turnType;
    private void Start()
    {
        teleport.enabled = true;
        snapTurn.enabled = true;
    }
    public void MovementBTN()
    {
        movementType = !movementType;

        if (movementType)
        {
            movement.enabled = true;
            teleport.enabled = false;
        }
        else
        {
            teleport.enabled = true;
            movement.enabled = false;
        }
        
    }
    public void TurnBTN()
    {
        turnType =! turnType;

        if (turnType)
        {
            smoothTurn.enabled = true;
            snapTurn.enabled = false;
        }
        else
        {
            snapTurn.enabled = true;
            smoothTurn.enabled = false;
        }
        
    }
    public void SnapTurnDegreesUI(int intdex)
    {
        switch (intdex)
        {
            case 0: snapTurn.turnAmount = 15; print("15"); break;
            case 1: snapTurn.turnAmount = 45; print("45"); break;
            case 2: snapTurn.turnAmount = 90; print("90"); break;
        }
    }
    public void SnapTurnDegreesIG()
    {
        switch(index)
        {
            case 0: snapTurn.turnAmount = 15; print("15"); break;
            case 1: snapTurn.turnAmount = 45; print("45"); break;
            case 2: snapTurn.turnAmount = 90; print("90"); break;
        }

        if (index == 2)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }
}
