using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public bool isTriggerPulled = false;
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isTriggerPulled)
        {

            OnTriggerHold();

        }
    }

    public abstract void OnTriggerPull();
    public abstract void OnTriggerRelease();
    public abstract void OnTriggerHold();

}
