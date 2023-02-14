using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject movePos;




    public List<string> dialogueS = new List<string>();

    private void Start()
    {
       GetDialogue();
    }
    private void GetDialogue()
    {
        for (int i = 0; i < movePos.GetComponent<MovePosition>().posText.text.Length; i++)
        {
            dialogueS.Add(movePos.GetComponent<MovePosition>().posText.text[i]);
            dialogue.SetLines(dialogueS[i]);
        }
    }
}
