using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration = 5f; // Adjust the duration of the power-up as needed
    public int powerUpStrength = 2;   // Adjust the strength of the power-up as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If the power-up collides with the player, activate the power-up
            ActivatePowerUp(other.gameObject);

            // You can also add other effects or behaviors here, like power-up pickup sound or visual effects
            Destroy(gameObject);
        }
    }

    void ActivatePowerUp(GameObject player)
    {
        // Assume the player has a PowerUpController script to handle power-up effects
        PowerUpController powerUpController = player.GetComponent<PowerUpController>();
        
        if (powerUpController != null)
        {
            powerUpController.ApplyPowerUp(powerUpStrength, powerUpDuration);
        }
    }
}
