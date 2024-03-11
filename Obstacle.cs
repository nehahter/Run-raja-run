using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1; // Adjust the damage as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If the obstacle collides with the player, apply damage
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // You can also add other effects or behaviors here, like obstacle destruction
            Destroy(gameObject);
        }
    }
}
