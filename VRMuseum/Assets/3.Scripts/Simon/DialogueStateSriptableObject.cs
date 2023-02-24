using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringState", menuName ="ScriptableObject/StringState")]
public class StringStateScriptableObject : ScriptableObject
{
    public string State = "0";
    public string previousState; 
    
}


