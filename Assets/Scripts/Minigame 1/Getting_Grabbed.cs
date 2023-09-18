using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Getting_Grabbed : XRGrabInteractable
{
    public GameObject leftHand;
    public GameObject rightHand;

    void Start()
    {
    }

    public void GetReleased()
    {
        this.transform.SetParent(null);
        Marshmallow_Minigame.instance.grabbing_hand = null;
        //Debug.Log("REGISTRO: " + Marshmallow_Minigame.instance.grabbing_hand);
    }

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        Debug.Log(interactor.gameObject.name);
        if(interactor.gameObject.name == "Left Hand Controller" && Marshmallow_Minigame.instance.grabbing_hand == null)
        {
            //this.transform.SetParent(leftHand.transform);
            Marshmallow_Minigame.instance.grabbing_hand = "Left Hand";
            //Debug.Log("REGISTRO: " + Marshmallow_Minigame.instance.grabbing_hand);
        }
        else if(interactor.gameObject.name == "Right Hand Controller" && Marshmallow_Minigame.instance.grabbing_hand == null)
        {
            //this.transform.SetParent(rightHand.transform);
            Marshmallow_Minigame.instance.grabbing_hand = "Right Hand";
            //Debug.Log("REGISTRO: " + Marshmallow_Minigame.instance.grabbing_hand);
        }
    }
}
