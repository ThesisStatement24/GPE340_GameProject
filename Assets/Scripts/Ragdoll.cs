using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    private Animator anim;
    private Collider topCollider;
    private Rigidbody topRigidbody;
    private List<Collider> ragdollColliders;
    private List<Rigidbody> ragdollRigidbodies;
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        topCollider = GetComponent<Collider>();
        topRigidbody = GetComponent<Rigidbody>();
        health = GetComponent<Health>();

        ragdollColliders = new List<Collider>(GetComponentsInChildren<Collider>());
        ragdollRigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());

        // Start NOT in ragdoll
        StopRagdoll();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {

            StartRagdoll();

        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            StopRagdoll();

        }
    }

    public void StartRagdoll()
    {
        // Turn off my animator
        anim.enabled = false;
        
        // Turn ON the ragdoll colliders
        foreach(Collider currentCollider in ragdollColliders)
        {

            currentCollider.enabled = true;

        }
        // Turn ON the ragdoll rigidbodies
        foreach (Rigidbody currentRigidbody in ragdollRigidbodies)
        {

            currentRigidbody.isKinematic = false;

        }

        // Turn off the big (top) capsule collider
        topCollider.enabled = false;
        // Turn off the big (top) rigidbody
        topRigidbody.isKinematic = true;

    }

    public void StopRagdoll()
    {
        // Turn on the animator
        anim.enabled = true;
        
        // Turn off the ragdoll colliders
        foreach (Collider currentCollider in ragdollColliders)
        {

            currentCollider.enabled = false;

        }
        // Turn off the ragdoll rigidbodies
        foreach (Rigidbody currentRigidbody in ragdollRigidbodies)
        {

            currentRigidbody.isKinematic = true;

        }

        // Turn on the top capsule collider
        topCollider.enabled = true;
        // Turn on the top rigidbody
        topRigidbody.isKinematic = false;


    }

}
