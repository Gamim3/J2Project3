using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable() {
        EventManager.OnClicked += Jump;    
    }

    private void OnDisable() {
        EventManager.OnClicked -= Jump;
    }
    public void Jump() {
        rb.AddForce(Vector3.up*Random.Range(0,500));
    }
}
