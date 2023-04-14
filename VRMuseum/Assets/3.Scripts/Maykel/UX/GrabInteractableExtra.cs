using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInteractableExtra : XRGrabInteractable
{
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        base.OnSelectEntered(interactor);
    }
    protected override void Detach()
    {
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        base.Detach();
    }
}
