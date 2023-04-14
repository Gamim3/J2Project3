using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARbrill : MonoBehaviour
{
    [SerializeField] private GameObject[] arblocks;

    public void RenderBlocks()
    {
        for (int i = 0; i < arblocks.Length; i++)
        {
            arblocks[i].active = true;
        }
    }
    public void NoRenderBlocks()
    {
        for (int i = 0; i < arblocks.Length; i++)
        {
            arblocks[i].active = false;
        }
    }
}
