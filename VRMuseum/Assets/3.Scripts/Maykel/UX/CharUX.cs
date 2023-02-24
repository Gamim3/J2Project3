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
    [SerializeField] private int index;

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private int audioStep;

    [SerializeField] private Dialogue dialogue;
    private void Start()
    {
        teleport.enabled = true;
        snapTurn.enabled = true;
    }
    public void MovementBTN()
    {
        movement.enabled = true;
        dialogue.teleport = false;
        teleport.enabled = false;
    }
    public void TeleportBTN()
    {
        teleport.enabled = true;
        dialogue.teleport = true;
        movement.enabled = false;
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
    public void SetVolumeUI(float sliderValue)
    {
        print(sliderValue);
        mixer.SetFloat("MyMixTape", Mathf.Log10(sliderValue) * 20);
    }
    public void SetVolumeIG(int btnInt)
    {
        switch (btnInt)
        {
            case 0: mixer.SetFloat("MyMixTape", Mathf.Log10(audioStep) * 20); break;
            case 1: mixer.SetFloat("MyMixTape", Mathf.Log10(audioStep) * 20); break;
        }
    }
    public void SetDialougeClipSpeed()
    {
        dialogue.TextSpeedClipSpeed();
    }

}
