using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Guide guide;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private List<string> lines = new List<string>();
    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();
    [SerializeField] private float textSpeed;
    [SerializeField] private int index;
    private int lineLength;

    [SerializeField] private bool textSpeedIsClipSpeed; 

    public bool canGoToNextText;
    [SerializeField] private bool end;

    private void Start()
    {
        textComponent.text = null;
    }
    public void Startdialogue()
    {
        index = 0;

        StartCoroutine(ParseDialogue());
    }
    private void RemoveDialogue()
    {
        textComponent.text = null;
        lines.RemoveRange(0, lines.Count);
        guide.RemoveDialogue();
        
        //clips.Clear();
    }

    //public void SetDialogue(string text, AudioClip voice)
    //{
    //    lines.Add(text);
    //    clips.Add(voice);
    //}
    public void TextSpeedClipSpeed()
    {
        textSpeedIsClipSpeed =! textSpeedIsClipSpeed;
    }
    public void SetDialogue(string text)
    {
        lines.Add(text);
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


            if (textSpeedIsClipSpeed)
            {
                yield return new WaitForSeconds(clips[index].length);
            } 
            else
            {
                yield return new WaitForSeconds(10 / textSpeed);
            }
        }
    }
    public void Button()
    {
        if (end && index != lines.Count - 1)
        {
            if (canGoToNextText)
            {
                print("q");
                textComponent.text = null;
                lineLength = 0;
                index++;
                end = false;
                StartCoroutine(ParseDialogue());
            }
        }
        else if (!end)
        {
            print("Q");
            StopAllCoroutines();
            textComponent.text = null;
            index++;
            foreach (char c in lines[index].ToCharArray())
            {
                CheckTextModifier(c);
            }
            end = true;

        }

        if (end && index == lines.Count -1)
        {            
            RemoveDialogue();
            guide.canChangePos = true;
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