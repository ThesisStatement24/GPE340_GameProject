using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{

    public float amountToHeal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            transform.Rotate(0, 2, 0);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        Health healthComponent = other.GetComponent<Health>();
        healthComponent.Heal(amountToHeal);
        Destroy(this.gameObject);
    }

    public override void OnPickup()
    {
        


    }
}
