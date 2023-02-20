using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharUX : MonoBehaviour
{
    [SerializeField] private ContinuousMoveProviderBase movement;
    [SerializeField] private TeleportationProvider teleport;
    [SerializeField] private ContinuousTurnProviderBase smoothTurn;
    [SerializeField] private SnapTurnProviderBase snapTurn;

    private void Start()
    {
        teleport.enabled = true;
        snapTurn.enabled = true;
    }
    public void MovementBTN()
    {
        movement.enabled = true;
        teleport.enabled = false;
    }
    public void TeleportBTN()
    {
        teleport.enabled = true;
        movement.enabled = true;
    }
    public void SmoothTurnBTN()
    {
        smoothTurn.enabled = true;
        snapTurn.enabled = false;
    }
    public void SnapTurnBTN()
    {
        snapTurn.enabled = true;
        smoothTurn.enabled = false;
    }
    public void Dropdown(int index)
    {
        switch(index)
        {
            case 0: snapTurn.turnAmount = 15; print("15"); break;
            case 1: snapTurn.turnAmount = 45; print("45"); break;
            case 2: snapTurn.turnAmount = 90; print("90"); break;
        }
    }
}
