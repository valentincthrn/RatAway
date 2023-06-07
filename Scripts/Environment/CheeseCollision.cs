using UnityEngine;

public class CheeseCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerScore.instance.AddScore(1); // Increase the player's score by 1
            Destroy(gameObject); // Destroy the point cube
        }
    }
}
