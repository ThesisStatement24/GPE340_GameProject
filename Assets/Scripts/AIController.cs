using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform followTarget;
    public float decisionDelay = 1.0f;
    private float nextDecisionTime;
    private Pawn pawn;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nextDecisionTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        // If it is time to update
        if (Time.time >= nextDecisionTime)
        {
            // Do I have a target? If NOT:
            if(followTarget == null)
            {
                // Find the player as target
                followTarget = GetFollowTarget();
                // If I still have no target:
                if(followTarget == null)
                {

                    // There is no player!!!
                    // Stop my AI and exit the Update
                    agent.Stop();
                    pawn.anim.SetFloat("Forward", 0.0f);
                    pawn.anim.SetFloat("Right", 0.0f);
                    // Exit the Update!
                    return;

                }

            }

            // Update (set a path to target)
            agent.SetDestination(followTarget.position);
            // Save our next decision time
            nextDecisionTime = Time.time + decisionDelay;

        }

        // Get the desired movement from the agent
        Vector3 desiredMovement = agent.desiredVelocity;
        // Invert it (so it works with our root motion animator)
        desiredMovement = this.transform.InverseTransformDirection(desiredMovement);
        // Remove the speed by normalizing to 1
        desiredMovement = desiredMovement.normalized;
        // Use my pawn's speed
        desiredMovement *= pawn.speed;
        

    }

    public Transform GetFollowTarget()
    {
        // Variable to store the target we will return
        Transform target = null;

        // Get the player
        HumanController player = FindObjectOfType<HumanController>();
        // Get the transform component off the pawn of that controller
        if (player != null)
        {
            if (player.pawn != null)
            {
             
                target = player.pawn.transform;

            }

        }
        // Return the target
        return target;
    }

    public Transform GetNearestHumanControllerTransform()
    {

        // Get a list of all my HumanControllers
        HumanController[] allHumanControllers = FindObjectsOfType<HumanController>();
        // Create a variable to hold the target and assume the first one is closest
        Transform ClosestTarget = allHumanControllers[0].transform;
        // Find and store distance to pawn
        float closestDistanceToPawn = Vector3.Distance(pawn.transform.position, ClosestTarget.transform.position);

        // Iterate through all
        foreach (HumanController hc in allHumanControllers)
        {

            // If this new one is closer,
            float distanceToPawn = Vector3.Distance(pawn.transform.position, hc.pawn.transform.position);
            if(distanceToPawn <= closestDistanceToPawn)
            {

                // then it is the closest
                ClosestTarget = hc.transform;
                closestDistanceToPawn = distanceToPawn;

            }



        }
        // After we've looked at everything, return the closest
        return ClosestTarget;

    }

    private void OnAnimatorMove()
    {
        // Every time the animator moves us, tell NavMeshAgent how we moved, so it can use that in calculations
        agent.velocity = anim.velocity;
    }

}
