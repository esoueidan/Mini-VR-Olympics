using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jindong : MonoBehaviour
{
    public float hapticDuration = 0.1f;
    public float hapticAmplitude = 0.5f;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component is missing.");
        }
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject as XRBaseControllerInteractor;

        if (interactor != null)
        {
            var controller = interactor.xrController;
            if (controller != null)
            {
                controller.SendHapticImpulse(hapticAmplitude, hapticDuration);
            }
        }
    }
}
