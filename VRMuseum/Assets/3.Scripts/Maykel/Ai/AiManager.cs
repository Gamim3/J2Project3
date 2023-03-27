using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class AiManager : MonoBehaviour
{
    [SerializeField] private Transform[] agentPos;
    [SerializeField] public Transform[] agents;
    [SerializeField] private bool[] isOccupied;
    [SerializeField] private int randomPos;
    [SerializeField] private bool alloc;

    [SerializeField] private Transform[] guidePos;
    [SerializeField] private Transform guide;
    [SerializeField] public int guideIndex;
    [SerializeField] private bool tour;
    [SerializeField] private Dialogue dialogue;
    public void ChangePosGuide()
    {
        if (guideIndex >= guidePos.Length)
        {
            tour = false;
            dialogue.canGoToNextText = false;
            guideIndex--;
        }

        guide.GetComponent<Guide>().MoveToPos(guidePos[guideIndex]);
        //guidePos[guideIndex].GetComponent<MovePosition>().EnableTelePort();
        if (tour)
        {
            guideIndex++;
        }
        else
        {
            for (int i = 0; i < guidePos.Length; i++)
            {
                guidePos[i].GetComponent<MovePosition>().freeRoam = true;
            }
        }
    }
    public void ResetTour()
    {
        guideIndex = 0;
    }
    public void ChangeAgentPositionNPC(int i)
    {
        if (agents[i].GetComponent<AiMover>().movePosition == null && agents[i].GetComponent<AiMover>().canChange) {

            GetRandomPos();

            agents[i].GetComponent<AiMover>().movePosition = agentPos[randomPos];
            print("BAbA");
            isOccupied[randomPos] = true;

        }
    }
    private void GetRandomPos()
    {
        print("randompos");
        randomPos = Random.Range(0, agentPos.Length);
        int ass = 0;

        for (int i = 0; i < agentPos.Length; i++)
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
        for (int i = 0; i < agentPos.Length; i++)
        {
            if (agentPos[i].position == position.position)
            {
                isOccupied[i] = false;
            }
        }
    }
}
