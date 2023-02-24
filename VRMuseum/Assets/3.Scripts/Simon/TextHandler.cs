using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{
    [SerializeField] public TextMeshPro myTextElement;

    public DialogueTree dState;
    public Dictionary<string, string> dialogueDict;

    uint c = 0;

    private void Start() {
        DisplayText();
    }
    private void OnEnable() {
        EventManager.OnClicked += CountClick;   
        EventManager.OnYes += NextStateA;
        EventManager.OnNo += NextStateB;
        EventManager.OnPrev += PrevState; 
    }
    private void OnDisable() {
        EventManager.OnClicked -= CountClick;
        EventManager.OnYes -= NextStateA;
        EventManager.OnNo -= NextStateB;
        EventManager.OnPrev -= PrevState; 
    }

    public void CountClick() {
        c++;
        DisplayText("Clicked "+c+" times");
    }

    public void NextStateA(){
        if(CheckNextState("a")){
        dState.state += "a";
        }
        DisplayText();
    }
    public void NextStateB(){
        if(CheckNextState("b")){
        dState.state += "b";
        }
        DisplayText();
    }

    public void PrevState(){
        
        if(dState!=null&&dState.state.Length!=0){
            dState.state = dState.state.Remove(dState.state.Length-1,1);
        }
        DisplayText();
    }

    public void DisplayText(){
        for(int i = 0; i<dState.dialogueUnits.Length; i++){
            if(dState.dialogueUnits[i].stateKey == dState.state){
                myTextElement.text = dState.dialogueUnits[i].sentence;
                return;
            } else if(dState.state == ""){
                myTextElement.text = dState.startMessage;
                return;
            }
        }
        myTextElement.text = "Option for State " + dState.state + " not yet implemented.";
        
    }
    public void DisplayText(string text){
        myTextElement.text = text;
    }

    public bool CheckNextState(string next){
        string fullNextState = dState.state + next;
        for(int i = 0; i<dState.dialogueUnits.Length; i++){
            if(dState.dialogueUnits[i].stateKey == fullNextState){
                return true;
            }
        }
        return false;
    }
    
}