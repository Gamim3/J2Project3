using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{

    public DialogueStateScriptableObject dialogueStateObject;
    // States of the Dialogue is saved as strings where the lentgh is how far along you are and the character is the option chosen
    public string beginState = "0";


    private void Start(){
        // OnEnable the begin state is being reloaded as current state
        dialogueStateObject.dialogueState = beginState;
        
    }

    public void NextDialogueOption(int option = 0){
        dialogueStateObject.dialogueState += option.ToString();
    }

    public void Back(){
        dialogueStateObject.dialogueState = dialogueStateObject.dialogueState.Remove(dialogueStateObject.dialogueState.Length -1, 1);
    }
    public void Back(int steps){
        while(steps >= 0){
            Back();
            steps--;
        }
    }
}
