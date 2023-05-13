using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TMP_Text healthText;

    // Update the displayed health value
    public void UpdateHealth(int currentHealth)
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
