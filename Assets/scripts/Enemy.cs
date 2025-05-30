using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float moveSpeed = 15f;
    public float maxDistance = 10f;

    private List<(GameObject enemy, Vector2 direction, bool outward)> activeEnemies = new();

    void Start()
    {
        SpawnAtParent(1f);
        SpawnAtParent(-1f);
    }

    public void SpawnAtParent(float cosValue)
    {
        cosValue = Mathf.Clamp(cosValue, -1f, 1f);
        float angleRad = Mathf.Acos(cosValue);
        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;

        GameObject enemy = Instantiate(
            enemyPrefab,
            transform.position,
            Quaternion.identity
        );

        if (enemy.GetComponent<EnemyCollision>() == null)
        {
            enemy.AddComponent<EnemyCollision>();
        }

        activeEnemies.Add((enemy, direction, true));
    }

    public void SpawnRandomEnemy()
    {
        float randomCos = Random.Range(-1f, 1f);
        SpawnAtParent(randomCos);
    }

    void Update()
    {
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            var (enemy, direction, outward) = activeEnemies[i];
            if (enemy == null) continue;

            Vector3 parentPos = transform.position;
            Vector3 enemyPos = enemy.transform.position;
            Vector3 moveDir = direction;

            float distance = Vector3.Distance(parentPos, enemyPos);

            if (outward)
            {
                if (distance >= maxDistance)
                {
                    outward = false;
                }
            }
            else
            {
                if (distance <= 0.5f)
                {
                    outward = true;
                }
                moveDir = (parentPos - enemyPos).normalized;
            }

            enemy.transform.position += (Vector3)(moveDir * moveSpeed * Time.deltaTime);


            activeEnemies[i] = (enemy, direction, outward);
        }
    }
}
