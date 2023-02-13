using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Dialogue
    {
    public string speaker;
    public string line;
    }

    public class DialogueManager : MonoBehaviour
{
    public List<Dialogue> dialogues;
    private int currentDialogue;

    public Text speakerText;
    public Text dialogueText;

    public GameObject dialogueBox;

    public void ShowDialogue()
    {
        Dialogue current = dialogues[currentDialogue];
        speakerText.text = current.speaker;
        dialogueText.text = current.line;
        dialogueBox.SetActive(true);
    }

    public void NextDialogue()
    {
        currentDialogue++;
        if (currentDialogue >= dialogues.Count)
        {
            HideDialogue();
            return;
        }
        ShowDialogue();
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }
}


}
