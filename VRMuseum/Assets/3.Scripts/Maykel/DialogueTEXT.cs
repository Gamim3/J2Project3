using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Text", order = 1)]
public class DialogueTEXT : ScriptableObject
{
    public string[] text;
    public AudioClip[] audios;

}
