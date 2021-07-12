using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    public float currentHealth;
    private Ragdoll ragdoll;
    public UnityEvent OnHeal;
    public Text healthText;


    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {

            OnDeath();

        }

        // Print currentHealth to UI
        healthText.text = "Health: " + currentHealth;

    }

    public void PlayHealthSound()
    {

        // TODO: Play the heal sound at my location

    }

    public void PlayHealthParticle()
    {

        // TODO: Play the health particle at my location

    }

    public void Heal (float amountToHeal)
    {
        // Add amount to health
        currentHealth += amountToHeal;
        // Don't go over max
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        // Call all the functions connected to our OnHeal event
        OnHeal.Invoke();

    }


    public void takeDamage(float damageAmount)
    {

        // Remove amount from health
        currentHealth -= damageAmount;

    }

    public void OnDeath()
    {

        // Make Character Ragdoll on death
        ragdoll.StartRagdoll();

    }

}
