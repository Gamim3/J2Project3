using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    private int index;


    private void Start()
    {
        textComponent.text = null;
        Startdialogue();
    }
    private void Startdialogue()
    {
        index = 0;

        StartCoroutine(ParseDialogue());
    }

    IEnumerator ParseDialogue()
    {
        foreach (char c in lines[index].ToCharArray()) {
            CheckTextModifier(c);
            yield return new WaitForSeconds(textSpeed);
        }
        
    }

    public void Button()
    {
        print("click");
        if (textComponent.text == lines[index]) {
            textComponent.text = null;
            index++;
            ParseDialogue();
        } else {

        }
    }

    private void CheckTextModifier(char chars)
    {
        if (chars == '<') {
            textComponent.text += "<i>";
        } else if (chars == '>') {
            textComponent.text += "</i>";
        } else if (chars == '(') {
            textComponent.text += "<b>";
        } else if (chars == ')') {
            textComponent.text += "</b>";
        } else if (chars == '[') {
            textComponent.text += "<u>";
        } else if (chars == ']') {
            textComponent.text += "</u>";
        } else {
            textComponent.text += chars;
        }
    }
}
