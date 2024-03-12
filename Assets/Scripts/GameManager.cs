using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour


{
    public Text scoreText;
    public Player player;
    
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;

    public int lives = 3;
    public int score = 0;
    



    public void AsteroidDestroyed(Asteroid asteroid)
    {
        transform.position = asteroid.transform.position;
         scoreText.text = score.ToString();
    
         this.score += 25;
        

        
    }

    public void PlayerDied()
    {
        this.lives--;

        if (this.lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }

    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        // TODO
    }

}
