using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTriggerScript : MonoBehaviour
{
    public GameObject arbrill;
    public MeshRenderer arbrillMesh;
    public bool brillOn;
    public GameObject holder;

    private void Start()
    {
        arbrillMesh = arbrill.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == arbrill)
        {
            brillOn = true;
            arbrill.GetComponent<Rigidbody>().useGravity = false;
            //arbrillMesh.enabled = false;
            holder.GetComponent<ARbrill>().RenderBlocks();
            arbrill.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == arbrill)
        {
            brillOn = false;
            arbrill.GetComponent<Rigidbody>().useGravity = true;
            //arbrillMesh.enabled = true;
            holder.GetComponent<ARbrill>().NoRenderBlocks();
            arbrill.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
    private void Update()
    {
        if(brillOn == true)
        {
            arbrill.transform.position = holder.transform.position;
            arbrill.transform.rotation = holder.transform.rotation;
        }
        else
        {
            arbrill.GetComponent<Rigidbody>().useGravity = true;
            arbrill.GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
