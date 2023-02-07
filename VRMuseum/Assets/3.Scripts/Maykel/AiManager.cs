using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class AiManager : MonoBehaviour
{
    [SerializeField] private Transform[] movePositions;
    [SerializeField] public Transform[] agents;
    [SerializeField] private bool[] isOccupied;
    [SerializeField] private int randomPos;

    [SerializeField] private bool alloc;
    private void Update() {
        // Check if movePosition is occupied
        // Make look direction correct depending on what the position is
        // Randomize Positions


        
    }
    public void ChangeAgentPosition(int i)
    {
        if (agents[i].GetComponent<AiMover>().movePosition == null && agents[i].GetComponent<AiMover>().canChange) {

            GetRandomPos();

            agents[i].GetComponent<AiMover>().movePosition = movePositions[randomPos];
            print("BAbA");
            isOccupied[randomPos] = true;

        }
    }
    private void GetRandomPos()
    {
        print("randompos");
        randomPos = Random.Range(0, movePositions.Length);
        int ass = 0;

        for (int i = 0; i < movePositions.Length; i++)
        {
            if (isOccupied[i])
            {
                ass++;
            }
        }

        if (ass == isOccupied.Length)
        {
            alloc = true;
            return;
        }
        else
        {
            alloc = false;
        }

        if (isOccupied[randomPos])
        {
            GetRandomPos();
        }
        else
        {
            return;
        }
    }
    public void UnOccupie(Transform position)
    {
        for (int i = 0; i < movePositions.Length; i++)
        {
            if (movePositions[i].position == position.position)
            {
                isOccupied[i] = false;
            }
        }
    }
}
