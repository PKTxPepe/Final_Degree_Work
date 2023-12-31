using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;
    private bool isGrabbed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
        isGrabbed = false;
    }

    public void EnableHandCollider(){
        if(!isGrabbed){
            foreach(var item in handColliders){
            item.enabled = true;
        }
        }
    }

    public void DisableHandCollider(){
        isGrabbed = true;
        foreach(var item in handColliders){
            item.enabled = false;
        }
    }
    public void EnableHandColliderDelay(float delay){
        isGrabbed = false;
        Invoke(nameof(EnableHandCollider), delay);
    }
    
    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
