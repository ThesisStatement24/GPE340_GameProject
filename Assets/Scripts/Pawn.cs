using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    public Animator anim;
    public float speed = 5;
    public float turnSpeed = 180;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the direction my stick (or keys) are pressed
        Vector3 stickDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Make sure that direction can't go farther than a distance of 1
        stickDirection = Vector3.ClampMagnitude(stickDirection, 1);
        //Invert so that movement is world direction based, not local to rotation of character
        Vector3 animationDirection = transform.InverseTransformDirection(stickDirection);
        //Pass the floats into the animator to choose the right animation
        anim.SetFloat("Forward", animationDirection.z * speed);
        anim.SetFloat("Right", animationDirection.x * speed);

        //Rotate to Face Mouse
        RotateToMousePointer();

    }


    public void RotateToMousePointer ()
    {

        //Find the plane the character is standing on
        Plane groundPlane = new Plane(Vector3.up, transform.position);

        //Draw a ray from the mousepointer on the screen towards the plane we are standing on
        Ray theRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        //Using the distance to the intersection of plane and ray, find the point in World Spac*e
        float distance;
        groundPlane.Raycast(theRay, out distance);
        Vector3 targetPoint = theRay.GetPoint(distance);

        //Rotate towards that point
        RotateTowards(targetPoint);

    }



    public void RotateTowards (Vector3 lookAtPoint)
    {
        //Find the rotation to look at our lookAtPoint
        Quaternion goalRotation;
        goalRotation = Quaternion.LookRotation( lookAtPoint - transform.position , Vector3.up);

        //Rotate a little bit (less than our turn speed) towards our goal
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime);



    }

}
