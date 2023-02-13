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
    [SerializeField] private int index;
    private int lineLength;


    [SerializeField] private bool canGoToNextText;
    private bool end;

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
    public void SetTextSpeed(float newTextSpeed)
    {
        textSpeed = newTextSpeed;
    }
    IEnumerator ParseDialogue()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            CheckTextModifier(c);

            lineLength++;

            if (lineLength == lines[index].Length)
            {
                end = true;
            }

            yield return new WaitForSeconds(10 / textSpeed);
        }
    }
    public void Button()
    {
        if (end && index != lines.Length - 1)
        {
            if (canGoToNextText)
            {
                textComponent.text = null;
                lineLength = 0;
                index++;
                end = false;
                StartCoroutine(ParseDialogue());
            }
        }
        else if (!end)
        {
            StopAllCoroutines();
            textComponent.text = null;
            foreach (char c in lines[index].ToCharArray())
            {
                CheckTextModifier(c);
            }
            end = true;

        }
    }
    private readonly Dictionary<char, string> _textModifiers = new Dictionary<char, string>
{
    { '<', "<i>" },
    { '>', "</i>" },
    { '(', "<b>" },
    { ')', "</b>" },
    { '[', "<u>" },
    { ']', "</u>" }
};
    private void CheckTextModifier(char chars)
    {
        string tag;
        if (_textModifiers.TryGetValue(chars, out tag))
        {
            textComponent.text += tag;
        }
        else
        {
            textComponent.text += chars;
        }
    }
}