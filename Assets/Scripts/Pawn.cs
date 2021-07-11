using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{

    [HideInInspector] public Animator anim;
    public float speed = 5;
    public float turnSpeed = 180;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    

    public void EquipWeapon (Weapon weapon)
    {

        // TODO: Instantiate the Weapon
        // TODO: Set the weapon variable

    }



    public void RotateTowards (Vector3 lookAtPoint)
    {
        //Find the rotation to look at our lookAtPoint
        Quaternion goalRotation;
        goalRotation = Quaternion.LookRotation( lookAtPoint - transform.position , Vector3.up);

        //Rotate a little bit (less than our turn speed) towards our goal
        transform.rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, turnSpeed * Time.deltaTime);



    }

    public void AddToScore (float pointsToAdd)
    {

        //TODO: Add pointsToAdd to my score

    }

    public void OnAnimatorIK(int layerIndex)
    {

        if (weapon != null)
        {

            anim.SetLookAtPosition(weapon.transform.position + (5 * weapon.transform.forward));
            anim.SetLookAtWeight(1);

            if (weapon.rightHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

            }

            if (weapon.leftHandPoint != null)
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

            }


        }
        else 
        {

            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

            anim.SetLookAtWeight(0);
        }

    }

}
