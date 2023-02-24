using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueTree : ScriptableObject
{
    public string npcName;
    public string defaultState;
    public string startMessage;
    public string state; 
    public DialogueUnit[] dialogueUnits;
}

[Serializable]
public class DialogueUnit{
    public string stateKey;
    [TextArea(2,5)]
    public string sentence;
}


