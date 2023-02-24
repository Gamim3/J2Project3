using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour 
{
    private int buttonPos = Screen.width/5;
    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public static event ClickAction OnYes;
    public static event ClickAction OnNo;
    public static event ClickAction OnPrev;

    void OnGUI()
    {
        if(GUI.Button(new Rect(buttonPos - 50, 5, 100, 30), "Click"))
        {
            if(OnClicked != null)
                OnClicked();
        }
        if(GUI.Button(new Rect(buttonPos*2 - 50, 5, 100, 30), "Yes/Next"))
        {
            if(OnYes != null)
                OnYes();
        }
        if(GUI.Button(new Rect(buttonPos*3 - 50, 5, 100, 30), "No"))
        {
            if(OnNo != null)
                OnNo();
        }
        if(GUI.Button(new Rect(buttonPos*4 - 50, 5, 100, 30), "Prev"))
        {
            if(OnPrev != null)
                OnPrev();
        }
    }
}