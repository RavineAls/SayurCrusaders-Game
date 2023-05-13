using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth = 0;
    public HealthDisplay healthDisplay;
    public bool vulnerable = true;
    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        vulnerable = true;
        currentHealth = maxHealth;
        healthDisplay.UpdateHealth(currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthDisplay.UpdateHealth(currentHealth);
        StartCoroutine(playerIFrameCD());
    }

    public IEnumerator playerIFrameCD()
    {
        vulnerable = false;
        hitSound.Play();
        yield return new WaitForSeconds(1f);
        vulnerable = true;
    }
}
