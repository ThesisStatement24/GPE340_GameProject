using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    public float currentHealth;
    public float LifeCount;
    private Ragdoll ragdoll;
    public UnityEvent OnHeal;
    public Text healthText;
    public Text LifeText;
    public AudioSource DamageSound;


    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && LifeCount <= 0)
        {

            StartCoroutine("OnDeath");

        }

        // Print currentHealth to UI
        healthText.text = "Health: " + currentHealth;
        //Print LifeCount to UI
        LifeText.text = "Lives: " + LifeCount;

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
        DamageSound.Play();
    }

    IEnumerator OnDeath()
    {

        // Make Character Ragdoll on death
        ragdoll.StartRagdoll();
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);

    }

}
