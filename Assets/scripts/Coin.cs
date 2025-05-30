using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector2 minPosition = new Vector2(-12, -8);
    public Vector2 maxPosition = new Vector2(12, 8);

    [SerializeField] private Enemy enemyManager;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddPoint();
            }

            MoveToRandomPosition();

            if (enemyManager != null)
            {
                enemyManager.SpawnRandomEnemy();
            }
        }
    }

    private void MoveToRandomPosition()
    {
        float x = Random.Range(minPosition.x, maxPosition.x);
        float y = Random.Range(minPosition.y, maxPosition.y);
        transform.position = new Vector2(x, y);
    }
}