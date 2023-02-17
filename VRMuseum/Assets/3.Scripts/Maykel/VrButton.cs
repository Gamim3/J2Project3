using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class VrButton : MonoBehaviour
{

    [SerializeField] private GameObject button;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent onRelease;
    [SerializeField] private GameObject presser;
    [SerializeField] private bool isPressed;
    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 1f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print(other);
        print(presser);
        if (other.gameObject == presser.gameObject)
        {
            print(presser);
            button.transform.localPosition = new Vector3(0, 1.5f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
