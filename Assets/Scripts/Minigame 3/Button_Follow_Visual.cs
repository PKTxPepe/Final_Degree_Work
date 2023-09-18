using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Button_Follow_Visual : MonoBehaviour
{
    private XRBaseInteractable interactable;
    public Transform visualTarget;
    private Transform pokeAttachTransform;
    private Vector3 offset;
    private bool freeze = false;
    public float resetSpeed = 5;
    public float followAngle = 45;
    public Vector3 localAxis;
    private Vector3 initialLocalPos;
    private bool isFollowing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow); 
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
        initialLocalPos = visualTarget.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(freeze) return;

        if(isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
        }
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));
            if(pokeAngle < followAngle)
            {
                isFollowing = true;
                freeze = false;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            freeze = true;
        }
    }
}
