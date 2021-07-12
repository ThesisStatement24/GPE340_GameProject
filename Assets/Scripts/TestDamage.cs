using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{

    public Health health;

    // Start is called before the first frame update
    void Start()
    {

        health = GameObject.Find("Granny").GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void OnTriggerEnter(Collider other)
    {
        // Tell if player entered box
        if (other.gameObject.tag == "Player")
        {
            // Take damage away from player
            health.takeDamage(10);

        }

    }

}
