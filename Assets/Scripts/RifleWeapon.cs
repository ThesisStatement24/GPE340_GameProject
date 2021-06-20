using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : Weapon
{

    public void Shoot()
    {

        // TODO: Shoot one bullet!

    }

    // Start is called before the first frame update
    public override void Start()
    {

        base.Start();
        
    }

    // Update is called once per frame
    public override void Update()
    {

        base.Update();

    }

    public override void OnTriggerHold()
    {
        
    }

    public override void OnTriggerPull()
    {

        Shoot();

    }

    public override void OnTriggerRelease()
    {
        
    }

}
