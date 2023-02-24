using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DialogueManager", menuName = "ScriptableObject/DialogueManager")]
public class DialogueManagerScriptableObject : ScriptableObject
{

    private DialogueStateScriptableObject StateObject;

    [SerializeField]
    // States of the Dialogue is saved as strings where the lentgh is how far along you are and the character is the option chosen
    public string beginState = "0";

    [System.NonSerialized]
    public UnityEvent<int> dialogueChangeEvent;

    private void OnEnable(){
        // OnEnable the begin state is being reloaded as current state
        StateObject.dialogueState = beginState;
        if (dialogueChangeEvent == null){
            dialogueChangeEvent = new UnityEvent<int>();
        }
    }

    public void NextDialogueOption(int option = 0){
        StateObject.dialogueState += option.ToString();
        dialogueChangeEvent.Invoke(option);
    }
}
