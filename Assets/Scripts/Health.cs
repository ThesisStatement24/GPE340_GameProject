using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public UnityEvent OnHeal;
    public Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        HealthText.text = "Health: " + currentHealth;
        
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

}
