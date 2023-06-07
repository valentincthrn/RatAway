using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        // Update score UI
        UIManager.instance.UpdateScore(score);
    }
}
