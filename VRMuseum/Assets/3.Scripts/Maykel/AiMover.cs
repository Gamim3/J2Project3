using UnityEngine;
using UnityEngine.AI;

public class AiMover : MonoBehaviour
{
    [SerializeField] private AiManager manager;
    [SerializeField] public Transform movePosition;
    private NavMeshAgent agentMesh;
    [SerializeField] private Transform agentTr;
    [SerializeField] public bool canChange;

    [SerializeField] private int minWaittime;
    [SerializeField] private int maxWaittime;
    [SerializeField] private float waitTime;

    [SerializeField] private bool start;
    private void OnEnable() {
        agentMesh = GetComponent<NavMeshAgent>();
        manager = FindObjectOfType<AiManager>();
    }
    private void Start()
    {
        canChange = true;
        CheckAndChangePosStart();
    }
    private void Update() {

        if (start)
        {
            if (movePosition != null && canChange)
            {
                agentMesh.destination = movePosition.position;

                if (agentTr.position.x == movePosition.position.x && agentTr.position.z == movePosition.position.z)
                {
                    print("bingo bongo");
                    CheckAndChangePos();

                    canChange = false;
                    waitTime = Random.Range(minWaittime, maxWaittime);
                }
            }
            else if (!canChange)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
                if (waitTime <= 0)
                {
                    waitTime = Random.Range(minWaittime, maxWaittime);
                    print("waitted");
                    canChange = true;
                    CheckAndChangePos();
                    
                    
                }
            }
        }
    }
    private void CheckAndChangePos()
    {
        print("checkand");
        for (int i = 0; i < manager.agents.Length; i++) {
            if (manager.agents[i] == this.transform) {
                manager.UnOccupie(movePosition);
                movePosition = null;
                manager.ChangeAgentPositionNPC(i);
            }
        }
    }
    private void CheckAndChangePosStart()
    {
        print("STRT");
        for (int i = 0; i < manager.agents.Length; i++)
        {
            if (manager.agents[i] == this.transform)
            {
                manager.ChangeAgentPositionNPC(i);
                start = true;
            }
        }
    }
}
