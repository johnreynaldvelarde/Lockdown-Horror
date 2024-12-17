using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10; // Damage dealt to the player on collision

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the enemy collided with is the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the PlayerHealth script and apply damage
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy hit the player! Dealt " + damage + " damage.");
            }
        }
    }
}
