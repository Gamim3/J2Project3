using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guide : MonoBehaviour
{
    
    [SerializeField] private Transform guidePos;

    [SerializeField] private AiManager manager;
    [SerializeField] private NavMeshAgent agentMesh;    

    [SerializeField] private Dialogue dialogue;
    [SerializeField] private float dialogueTime;
    public List<string> guideLines = new List<string>();
    //public List<AudioClip> guideClips = new List<AudioClip>();

    public bool canChangePos;
    private void OnEnable()
    {
        agentMesh = GetComponent<NavMeshAgent>();
    }

    private void GetDialogue(Transform newPosition)
    {
        print("getdialogue");
        for (int i = 0; i < newPosition.GetComponent<MovePosition>().posText.text.Length; i++)
        {
            guideLines.Add(newPosition.GetComponent<MovePosition>().posText.text[i]);
            //guideClips.Add(newPosition.GetComponent<MovePosition>().posText.audios[i]);
            dialogue.SetDialogue(guideLines[i]);
            //dialogue.SetDialogue(guideLines[i], guideClips[i]);
        }
    }

    public void RemoveDialogue()
    {
        guideLines.RemoveRange(0, guideLines.Count);
    }
    private void Update()
    {
        if (canChangePos)
        {
            manager.ChangePosGuide();
            
            canChangePos = false;
        }
       
    }
    public void MoveToPos(Transform newPosition)
    {
        agentMesh.destination = newPosition.position;

        GetDialogue(newPosition);

        dialogue.Startdialogue();
    }
}
