using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    public DialogueTEXT posText;
    [SerializeField] private int thisPosIndex;
    [SerializeField] private AiManager manager;

    public bool freeRoam;

    private void OnTriggerEnter(Collider other)
    {
        if (freeRoam)
        {
            if (other.CompareTag("Player"))
            {
                manager.guideIndex = thisPosIndex;
            }
        }
    }
}
