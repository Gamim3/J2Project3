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
}
