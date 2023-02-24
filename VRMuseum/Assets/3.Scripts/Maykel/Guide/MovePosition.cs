using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    public DialogueTEXT posText;
    [SerializeField] private int thisPosIndex;
    [SerializeField] private AiManager manager;
    [SerializeField] private GameObject teleportAnchor;
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

    public void EnableTelePort()
    {
        teleportAnchor.SetActive(true);
    }
}
