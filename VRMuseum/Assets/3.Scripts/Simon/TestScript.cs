using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    public InputAction moveUp;
    public InputAction moveDown;
    public InputAction moveLeft;
    public InputAction moveRight;
    public float speed = 10f;
    Vector3 movement;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        moveUp = new InputAction("MoveUp", InputActionType.Value, "<Keyboard>/w");
        moveDown = new InputAction("MoveDown", InputActionType.Value, "<Keyboard>/s");
        moveLeft = new InputAction("MoveLeft", InputActionType.Value, "<Keyboard>/a");
        moveRight = new InputAction("MoveRight", InputActionType.Value, "<Keyboard>/d");

        moveUp.performed += ctx => MoveObject(Vector3.forward);
        moveDown.performed += ctx => MoveObject(Vector3.back);
        moveLeft.performed += ctx => MoveObject(Vector3.left);
        moveRight.performed += ctx => MoveObject(Vector3.right);

        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();

        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Rigidbody component not found on the object!");
        } else {
            Debug.Log("Rigidbody found");
        }
        rb.freezeRotation = true;
    }

    void MoveObject(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    // Not needed as the physics takes care of it!
    /*
    void StopMoving()
    {
        rb.velocity = rb.velocity*0.5f;
    }
    */
     
    // Update is called once per frame
    void Update()
    {
        
        if (moveUp.triggered)
        {
            movement = Vector3.forward;
        }
        else if(moveDown.triggered)
        {
            movement = Vector3.back;
        }

        if (moveLeft.triggered)
        {
            movement = Vector3.left;
        }
        else if (moveRight.triggered)
        {
            movement = Vector3.right;
        }
        MoveObject(movement);
    }
}
